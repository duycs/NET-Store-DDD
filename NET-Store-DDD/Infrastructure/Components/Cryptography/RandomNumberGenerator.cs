using System;
using System.Security.Cryptography;

namespace StoreDDD.Infrastructure.Components.Cryptography
{
    /// <summary>
    /// Class RandomNumberGenerator.
    /// </summary>
    public class RandomNumberGenerator
    {
        /// <summary>
        /// Generates the random cryptographic key.
        /// </summary>
        /// <param name="keyLength">Length of the key.</param>
        /// <returns>System.String.</returns>
        public string GenerateRandomCryptographicKey(int keyLength)
        {
            return Convert.ToBase64String(GenerateRandomCryptographicBytes(keyLength));
        }

        /// <summary>
        /// Generates the random cryptographic bytes.
        /// </summary>
        /// <param name="keyLength">Length of the key.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] GenerateRandomCryptographicBytes(int keyLength)
        {
            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}
