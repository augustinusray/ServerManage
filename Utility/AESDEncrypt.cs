using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public class AESDEncrypt
    {
        private static readonly string sskey = "TDeVdGOhAmnAQW4SIpQyrDO4r4vPokii";

        /// <summary>
        /// 固定加密
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Encrypt(string content)
        {
            return AesEncrypt(content, sskey);
        }

        /// <summary>
        /// 固定解密
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Decrypt(string content)
        {
            return AesDecrypt(content, sskey);
        }


        public static string AesEncrypt(string content, string key)
        {
            var encryptKey = Encoding.UTF8.GetBytes(key);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(encryptKey, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor,
                            CryptoStreamMode.Write))

                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(content);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result,
                            iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string AesDecrypt(string content, string key)
        {
            var fullCipher = Convert.FromBase64String(content);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var decryptKey = Encoding.UTF8.GetBytes(key);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(decryptKey, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt,
                            decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
