using System.Threading.Tasks;

namespace StoreDDD.DomainCore.Events
{
    /// <summary>
    /// Interface IEventDispatcher
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        Task RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}
