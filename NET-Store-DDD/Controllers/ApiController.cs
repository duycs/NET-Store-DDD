using System.Collections.Generic;
using System.Linq;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainCore.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreDDD.WebApi.Controllers
{
    /// <summary>
    /// Class ApiController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        private readonly ICommandDispatcher _commandBus;
        private readonly DomainNotificationHandler _notificationHandler;

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        protected IEnumerable<string> Errors => _notificationHandler.Notifications.Select(n => n.Value);

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiController" /> class.
        /// </summary>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBus">The command bus.</param>
        protected ApiController(INotificationHandler<DomainNotification> notificationHandler, ICommandDispatcher commandBus)
        {
            _notificationHandler = (DomainNotificationHandler)notificationHandler;
            _commandBus = commandBus;
        }

        /// <summary>
        /// Determines whether [is valid operation].
        /// </summary>
        /// <returns><c>true</c> if [is valid operation]; otherwise, <c>false</c>.</returns>
        protected bool IsValidOperation()
        {
            return (!_notificationHandler.HasNotifications());
        }
    }
}