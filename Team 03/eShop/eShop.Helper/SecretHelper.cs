using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Helper
{
    public class SecretHelper
    {
        private static string _passphrase = "eShop";

        public static string SHA512Encrypt(string input)
        {
            byte[] results;
            var utf8 = new UTF8Encoding();
            var hashProvider = new SHA512CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(_passphrase));

            var tdesAlgorithm = new AesCryptoServiceProvider();
            tdesAlgorithm.Key = tdesKey.Skip(17).Take(32).ToArray();
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] dataToEncrypt = utf8.GetBytes(input);
            try
            {
                ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

        public static string SHA512Decrypt(string input)
        {
            byte[] results;
            var utf8 = new UTF8Encoding();
            var hashProvider = new SHA512CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(_passphrase));
            var tdesAlgorithm = new AesCryptoServiceProvider();
            tdesAlgorithm.Key = tdesKey.Skip(17).Take(32).ToArray();
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] dataToDecrypt = Convert.FromBase64String(input);
            try
            {
                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return utf8.GetString(results);
        }
    }
}
