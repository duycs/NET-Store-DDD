using StoreDDD.DomainCore.Events;

namespace StoreDDD.DomainCore.Repository
{
    /// <summary>
    /// Interface IDomainEventRepository
    /// </summary>
    public interface IDomainEventRepository
    {
        /// <summary>
        /// Adds the specified domain event.
        /// </summary>
        /// <typeparam name="TDomainEvent">The type of the t domain event.</typeparam>
        /// <param name="domainEvent">The domain event.</param>
        void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;

        //IEnumerable<DomainEventRecord> FindAll();
    }
}
