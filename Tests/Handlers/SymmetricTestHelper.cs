using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Handlers
{
    public static class SymmetricTestHelper
    {
        public static (string encryted, string key, string iv) EncryptMessage(string msg)
        {
            string k;
            byte[] message = Encoding.UTF8.GetBytes(msg), key, iv, encrypted;
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.KeySize = 256;
                aesAlgorithm.GenerateKey();
                k = Convert.ToBase64String(aesAlgorithm.Key);
                key = aesAlgorithm.Key;
            }
            //string encrypted = null;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key; iv = aesAlg.IV;
                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(msg);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return (Convert.ToBase64String(encrypted), Convert.ToBase64String(key), Convert.ToBase64String(iv));
        }

        public static string DecryptMessage(string encrypted, string key, string iv)
        {
            var messageByte = Convert.FromBase64String(encrypted);
            var keyByte = Convert.FromBase64String(key);
            var IVByte = Convert.FromBase64String(iv);

            string msg = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyByte; aesAlg.IV = IVByte;
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(messageByte))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            msg = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return msg;
        }
    }
}
