using StoreDDD.DomainCore.Events;
using StoreDDD.DomainCore.Repository;
using StoreDDD.Infrastructure.Context;

namespace StoreDDD.Infrastructure.Repositories
{
    /// <summary>
    /// Class DomainEventRepository.
    /// </summary>
    public class DomainEventRepository : IDomainEventRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly EventStoreContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DomainEventRepository(EventStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds the specified domain event.
        /// </summary>
        /// <typeparam name="TDomainEvent">The type of the t domain event.</typeparam>
        /// <param name="domainEvent">The domain event.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent
        {
            _context.DomainEventRecords.Add(new DomainEventRecord()
            {
                Created = domainEvent.Created,
                Type = domainEvent.Type,
                Content = domainEvent.Content,
                CorrelationId = domainEvent.CorrelationId
            });
            _context.SaveChanges();
        }
    }
}
