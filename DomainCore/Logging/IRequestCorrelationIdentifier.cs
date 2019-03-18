namespace StoreDDD.DomainCore.Logging
{
    /// <summary>
    /// Interface IRequestCorrelationIdentifier
    /// </summary>
    public interface IRequestCorrelationIdentifier
    {
        /// <summary>
        /// Gets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        string CorrelationId { get; }
    }
}
