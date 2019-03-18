﻿using System.Threading;
using System.Threading.Tasks;
using StoreDDD.DomainCore.Events;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Events;
using StoreDDD.Infrastructure.Components.Mail;
using MediatR;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.EventHandlers
{
    /// <summary>
    /// Class CustomerCreatedEvents.
    /// </summary>
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        private readonly IEmailSender _emailSender;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCreatedEventHandler"/> class.
        /// </summary>
        /// <param name="emailSender">The email sender.</param>
        public CustomerCreatedEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        /// <summary>
        /// Handles the specified notification.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            _emailSender.SendEmailConfirmationAsync(notification.Customer.Email, "");
            return Task.CompletedTask;
        }
    }
}