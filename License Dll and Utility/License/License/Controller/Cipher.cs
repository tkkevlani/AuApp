using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using License.Model;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;

namespace License.Controller.Encryption
{
    [Serializable]
    public class EncryptorRSAKeys
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
    }

    public class Cipher
    {
        private static bool _optimalAsymmetricEncryptionPadding = false;

        #region RSA Encryption

        public static EncryptorRSAKeys GenerateKeys(int orgId)
        {
            if (orgId == 0)
                orgId = 1;
            int keySize = 1024;
            var pow = (int)Math.Pow(2, orgId);
            //keySize = (1024 + pow);

            if (keySize % 2 != 0 || keySize < 512)
                throw new Exception("Key should be multiple of two and greater than 512.");

            var response = new EncryptorRSAKeys();

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                var publicKey = provider.ToXmlString(false);
                var privateKey = provider.ToXmlString(true);

                var publicKeyWithSize = IncludeKeyInEncryptionString(publicKey, keySize);
                var privateKeyWithSize = IncludeKeyInEncryptionString(privateKey, keySize);

                response.PublicKey = publicKeyWithSize;
                response.PrivateKey = privateKeyWithSize;
            }

            return response;
        }

        public static string EncryptText(string text, string publicKey)
        {
            int keySize = 0;
            string publicKeyXml = "";

            GetKeyFromEncryptionString(publicKey, out keySize, out publicKeyXml);

            text = StringCompressor.CompressString(text);

            var encrypted = Encrypt(Encoding.UTF8.GetBytes(text), keySize, publicKeyXml);
            return Convert.ToBase64String(encrypted);
        }

        private static byte[] Encrypt(byte[] data, int keySize, string publicKeyXml)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentException("Data are empty", "data");
            int maxLength = GetMaxDataLength(keySize);
            if (data.Length > maxLength)
                throw new ArgumentException(String.Format("Maximum data length is {0}", maxLength), "data");
            if (!IsKeySizeValid(keySize))
                throw new ArgumentException("Key size is not valid", "keySize");
            if (String.IsNullOrEmpty(publicKeyXml))
                throw new ArgumentException("Key is null or empty", "publicKeyXml");

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                provider.FromXmlString(publicKeyXml);
                return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        public static string DecryptText(string text, string privateKey)
        {
            int keySize = 0;
            string publicAndPrivateKeyXml = "";

            GetKeyFromEncryptionString(privateKey, out keySize, out publicAndPrivateKeyXml);

            var decrypted = Decrypt(Convert.FromBase64String(text), keySize, publicAndPrivateKeyXml);
            return Encoding.UTF8.GetString(decrypted);
        }

        private static byte[] Decrypt(byte[] data, int keySize, string publicAndPrivateKeyXml)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentException("Data are empty", "data");
            if (!IsKeySizeValid(keySize))
                throw new ArgumentException("Key size is not valid", "keySize");
            if (String.IsNullOrEmpty(publicAndPrivateKeyXml))
                throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        private static int GetMaxDataLength(int keySize)
        {
            if (_optimalAsymmetricEncryptionPadding)
            {
                return ((keySize - 384) / 8) + 7;
            }
            return ((keySize - 384) / 8) + 37;
        }

        private static bool IsKeySizeValid(int keySize)
        {
            return keySize >= 384 &&
                    keySize <= 16384 &&
                    keySize % 8 == 0;
        }

        private static string IncludeKeyInEncryptionString(string publicKey, int keySize)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(keySize.ToString() + "!" + publicKey));
        }

        private static void GetKeyFromEncryptionString(string rawkey, out int keySize, out string xmlKey)
        {
            keySize = 0;
            xmlKey = "";

            if (rawkey != null && rawkey.Length > 0)
            {
                byte[] keyBytes = Convert.FromBase64String(rawkey);
                var stringKey = Encoding.UTF8.GetString(keyBytes);

                if (stringKey.Contains("!"))
                {
                    var splittedValues = stringKey.Split(new char[] { '!' }, 2);

                    try
                    {
                        keySize = int.Parse(splittedValues[0]);
                        xmlKey = splittedValues[1];
                    }
                    catch (Exception e) { }
                }
            }
        }

        #endregion

        public static string Encrypt(LicenseInfo license, string publicKey)
        {
            //var textData = Serialization.Serialize<LicenseInfo>(text);

            var textData = license.OrganizationId + "|" + license.ValidFrom.ToShortDateString() + "|" + license.ValidTo.ToShortDateString();

            string encryptedData = EncryptText(textData, publicKey);

            return encryptedData;
        }

        public static LicenseInfo Decrypt(string encryptedtext, LicenseInfo license, string privateKey)
        {
            bool isTampered = false;
            try
            {
                string decryptedData = DecryptText(encryptedtext, privateKey);
                decryptedData = StringCompressor.DecompressString(decryptedData);

                //var data = Serialization.Deserialize<LicenseInfo>(decryptedData);
                var extractData = decryptedData.Split('|');
                if (extractData != null && extractData.Count() > 0)
                {
                    if (license.OrganizationId.ToString() == extractData[0])
                    {
                        if (extractData[1] != null)
                        {
                            DateTime date;
                            DateTime.TryParse(extractData[1], out date);
                            license.ValidFrom = date;

                            if (extractData[2] != null)
                            {
                                DateTime.TryParse(extractData[2], out date);
                                license.ValidTo = date;
                            }
                            else
                                isTampered = true;
                        }
                        else
                            isTampered = true;
                    }
                    else
                        isTampered = true;
                }
                else
                    isTampered = true;
            }
            catch (Exception ex)
            {
                isTampered = true;
            }

            license.IsTampered = isTampered;

            return license;
        }

        public static string GenerateLicenseKey()
        {
            var key = Guid.NewGuid().ToString();

            return key;
        }
    }

    internal static class Serialization
    {
        #region Serialization & Deserialization

        internal static T Deserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        internal static string Serialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        #endregion
    }

    internal static class Hashing
    {

        #region Hashing
        internal static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);

            //return GetStringFromHash(hash);
        }

        internal static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        #endregion

    }

    internal static class StringCompressor
    {
        /// <summary>
        /// Compresses the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        public static string DecompressString(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }
    }

}