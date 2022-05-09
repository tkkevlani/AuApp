using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseUtility
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //TestEncryption();
            //TestDB();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LicenseForm());
            //Application.Run(new AddLicense());
        }

        static void TestDB()
        {

        }

        static void TestEncryption()
        {
            var keys = License.Controller.Encryption.Cipher.GenerateKeys(1);

            string text = "text for encryption";

            string encrypted = License.Controller.Encryption.Cipher.EncryptText(text, keys.PublicKey);
            string decrypted = License.Controller.Encryption.Cipher.DecryptText(encrypted, keys.PrivateKey);
        }
    }
}
