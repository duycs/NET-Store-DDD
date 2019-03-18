using System.Threading;
using System.Threading.Tasks;
using StoreDDD.DomainCore.Events;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Events;
using StoreDDD.Infrastructure.Components.Mail;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.EventHandlers
{
    /// <summary>
    /// Class CustomerCheckOutEventHandler.
    /// </summary>
    public class CustomerCheckOutEventHandler : IEventHandler<CustomerCheckOutEvent>
    {
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCheckOutEventHandler"/> class.
        /// </summary>
        /// <param name="emailSender">The email sender.</param>
        public CustomerCheckOutEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public Task Handle(CustomerCheckOutEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            _emailSender.SendEmailConfirmationAsync("", "");
            return Task.CompletedTask;
        }
    }
}