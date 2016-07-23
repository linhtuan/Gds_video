using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Gds.Setting.Cryptography
{
    public class CryptographyHelper
    {
        public static string AuthorKey = "gds^&(authories)";
        public static string CategoryKey = "gds^&(categorys)";
        public static string CategoryTypeKey = "gds^&(catetypes)";
        public static string VideoKey = "gds^&(videosids)";

        public static string Decrypt(string decrypt, string key)
        {
            decrypt = decrypt.Replace(" ", "+");
            int mode = decrypt.Length % 4;
            if (mode > 0)
                decrypt = decrypt.Substring(0, decrypt.Length - mode);

            const string vector = "1597836#";
            string value = CryptographyEngine.Decrypt(Convert.FromBase64String(decrypt), Encoding.UTF8.GetBytes(key),
                                                      Encoding.UTF8.GetBytes(vector));
            return value.Replace("\0", "");
        }

        public static string Encrypt(string encrypt, string key)
        {
            const string vector = "1597836#";
            byte[] value = CryptographyEngine.Encrypt(encrypt, Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(vector));
            return Convert.ToBase64String(value);
        }

        public static string RandomPassword(int length)
        {
            string guidResult = Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty);
            if (length <= 0 || length > guidResult.Length)
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

            return guidResult.Substring(0, length);
        }
    }

    internal class CryptographyEngine
    {
        public static byte[] Encrypt(string data, byte[] key, byte[] iv)
        {
            try
            {
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream,
                                               new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv),
                                               CryptoStreamMode.Write);
                byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();
                byte[] ret = mStream.ToArray();
                cStream.Close();
                mStream.Close();

                return ret;
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public static string Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            try
            {
                var mStream = new MemoryStream(data);
                var cStream = new CryptoStream(mStream,
                                               new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv),
                                               CryptoStreamMode.Read);
                var fromEncrypt = new byte[data.Length];
                cStream.Read(fromEncrypt, 0, fromEncrypt.Length);

                return new UnicodeEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}