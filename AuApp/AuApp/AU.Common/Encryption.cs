using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AU.Common
{
    public static class Encryption
    {
        static string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static string GenerateHash(string _password)
        {
            //Hashing and stuff
            /*make a new byte array*/
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            /*Hash and Salt it using PBKDF2*/
            var pbkdf2 = new Rfc2898DeriveBytes(_password, salt, 10000);

            //place the string in the byte array
            byte[] hash = pbkdf2.GetBytes(20);

            //make new array where to store the hashed password+salt
            //why 36? cause 20 are for the hash and 16 for the salt.

            byte[] hashBytes = new byte[36];

            //place the hash and salt in their respective places
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //now, convert our fancy bytes array to a string
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newHash"></param>
        /// <param name="savedHash"></param>
        /// <returns></returns>
        public static bool ComputeHash(string password, string savedHash)
        {

            //turn saved passowrd into bytes
            byte[] hashBytes = Convert.FromBase64String(savedHash);

            //take the salt out of the string
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            //hash the user inputted PW with the salt.
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            //put the hashed input into a byte array so we can compare it byte-by-byte.
            byte[] hash = pbkdf2.GetBytes(20);

            bool ok = true;
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    ok = true;
            if (ok == true)
                return true;
            else return false;
        }

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        /// <param name="password">Password</param>
        public static string Encrypt(string plainText)
        {
            if (plainText == null)
            {
                return null;
            }

            if (EncryptionKey == null)
            {
                EncryptionKey = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(EncryptionKey);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }
        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted</param>
        /// <param name="password">Password used during encryption</param>
        /// <exception cref="FormatException"></exception>
        public static string Decrypt(string encryptedText)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (EncryptionKey == null)
            {
                EncryptionKey = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(EncryptionKey);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        #region "Private methods"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytesToBeEncrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns></returns>
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[8];

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytesToBeDecrypted"></param>
        /// <param name="passwordBytes"></param>
        /// <returns></returns>
        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[8];

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        #endregion
    }
}
