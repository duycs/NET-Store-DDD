using System.Threading.Tasks;
using MediatR;

namespace StoreDDD.DomainCore.Events
{
    /// <summary>
    /// Class EventDispatcher.
    /// </summary>
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventDispatcher"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public Task RaiseEvent<T>(T @event) where T : DomainEvent
        {
            return _mediator.Publish(@event);
        }
    }
}
