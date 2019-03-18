using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace StoreDDD.Infrastructure.Components.Cryptography
{
    /// <summary>
    /// Class PasswordWithSaltHasher
    /// </summary>
    public static class PasswordWithSaltHasher
    {
        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="saltLength">Length of the salt.</param>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <returns>System.String.</returns>
        private static HashWithSaltResult Encrypt(string password, int saltLength, HashAlgorithm hashAlgorithm)
        {
            var rng = new RandomNumberGenerator();
            var saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
            var passwordAsBytes = Encoding.UTF8.GetBytes(password);
            var passwordWithSaltBytes = new List<byte>();

            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            var digestBytes = hashAlgorithm.ComputeHash(passwordWithSaltBytes.ToArray());

            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }

        /// <summary>
        /// Actions the encrypt.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="saltLength">Length of the salt.</param>
        /// <returns>HashWithSaltResult.</returns>
        public static HashWithSaltResult ActionEncrypt(string password, int saltLength)
        {
            return Encrypt(password, saltLength, SHA256.Create());
        }

        /// <summary>
        /// Decrypts this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string Decrypt()
        {

            return null;
        }

        /// <summary>
        /// Actions the decrypt.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        public static string ActionDecrypt(string password)
        {
            return Decrypt();
        }
    }
}
