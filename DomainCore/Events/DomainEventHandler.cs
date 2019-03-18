using System;
using System.Threading;
using System.Threading.Tasks;
using StoreDDD.DomainCore.Logging;
using StoreDDD.DomainCore.Repository;
using Newtonsoft.Json;

namespace StoreDDD.DomainCore.Events
{
    /// <summary>
    /// Class DomainEventHandler.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DomainEventHandler<T> : IEventHandler<T> where T : DomainEvent
    {
        private readonly IDomainEventRepository _domainEventRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventHandler{T}" /> class.
        /// </summary>
        /// <param name="domainEventRepository">The domain event repository.</param>
        public DomainEventHandler(IDomainEventRepository domainEventRepository)
        {
            _domainEventRepository = domainEventRepository;
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(T @event, CancellationToken cancellationToken)
        {
            @event.Flatten();
            @event.CorrelationId = Guid.NewGuid();
            @event.Content = JsonConvert.SerializeObject(@event.Args);

            _domainEventRepository.Add(@event);

            return Task.CompletedTask;
        }
    }
}
