using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TollManagement.Common;

namespace TollTicketManagement.Common
{
    public class EncodeString
    {
        private static string _passPhrase = "9L@!Td7tD"; // can be any string
        private static string _saltValue = "s@1tValue"; // can be any string
        private static string _hashAlgorithm = "SHA1"; // can be "MD5"
        private static int _passwordIterations = 2; // can be any number
        private static string _initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private static int _keySize = 256; // can be 192 or 128

        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be encrypted.
        /// </param>
        /// <returns>
        /// Encrypted value formatted as a base64-encoded string.
        /// </returns>
        public static string Encode(string plainText)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(_saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                var password = new PasswordDeriveBytes(
                    _passPhrase,
                    saltValueBytes,
                    _hashAlgorithm,
                    _passwordIterations);

                byte[] keyBytes = password.GetBytes(_keySize / 8);

                var symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                    keyBytes,
                    initVectorBytes);

                var memoryStream = new MemoryStream();

                var cryptoStream = new CryptoStream(memoryStream,
                                                    encryptor,
                                                    CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        /// </summary>
        /// <param name="cipherText">
        /// Base64-formatted ciphertext value.
        /// </param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        /// <remarks>
        /// Most of the logic in this function is similar to the Encrypt
        /// logic. In order for decryption to work, all parameters of this function
        /// - except cipherText value - must match the corresponding parameters of
        /// the Encrypt function which was called to generate the
        /// ciphertext.
        /// </remarks>
        public static string Decode(string cipherText)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(_saltValue);

                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                var password = new PasswordDeriveBytes(
                    _passPhrase,
                    saltValueBytes,
                    _hashAlgorithm,
                    _passwordIterations);

                byte[] keyBytes = password.GetBytes(_keySize / 8);

                var symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                    keyBytes,
                    initVectorBytes);
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream(memoryStream,
                                                    decryptor,
                                                    CryptoStreamMode.Read);
                var plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
                return plainText;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                }
                return string.Empty;
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(_saltValue);

                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                _hashAlgorithm,
                                                                _passwordIterations);

                byte[] keyBytes = password.GetBytes(_keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);
                /*  Read from cryptoStream is not a good way. Write to cryptoStream then 
                    read from memory stream is a better way.
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                */
                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Write);
                cryptoStream.Write(cipherTextBytes, 0, cipherTextBytes.Length);
                // Close to flush the stream
                cryptoStream.Close();
                byte[] plainTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                return plainText;
            }
            catch// (Exception ex)
            {
                return "Invalid encrypted string or password";  // ex.Message;
            }
        }
    }
}
