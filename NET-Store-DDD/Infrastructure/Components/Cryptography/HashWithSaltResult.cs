namespace StoreDDD.Infrastructure.Components.Cryptography
{
    /// <summary>
    /// Class HashWithSaltResult.
    /// </summary>
    public class HashWithSaltResult
    {
        /// <summary>
        /// Gets the salt.
        /// </summary>
        /// <value>The salt.</value>
        public string Salt { get; }

        /// <summary>
        /// Gets or sets the digest.
        /// </summary>
        /// <value>The digest.</value>
        public string Digest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashWithSaltResult"/> class.
        /// </summary>
        /// <param name="salt">The salt.</param>
        /// <param name="digest">The digest.</param>
        public HashWithSaltResult(string salt, string digest)
        {
            Salt = salt;
            Digest = digest;
        }
    }
}
