using MediatR;

namespace StoreDDD.DomainCore.Events
{
    /// <summary>
    /// Interface IEventHandler
    /// </summary>
    /// <typeparam name="TDomainEvent">The type of the t domain event.</typeparam>
    ///// <seealso cref="MediatR.INotificationHandler{TDomainEvent}" />
    public interface IEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
    }
}
