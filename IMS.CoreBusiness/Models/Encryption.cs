using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Encryption
    {
        public static string Encrypt(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = keyBytes;
            aes.IV = keyBytes;
            using var encryptor = aes.CreateEncryptor();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] outputBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            return Convert.ToBase64String(outputBytes);
        }

        public static string Decrypt(string input, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = keyBytes;
            aes.IV = keyBytes;
            using var decryptor = aes.CreateDecryptor();
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] outputBytes = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            return Encoding.UTF8.GetString(outputBytes);
        }
    }

}
