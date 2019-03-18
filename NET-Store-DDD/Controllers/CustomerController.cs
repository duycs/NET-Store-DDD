using System;
using System.Linq;
using StoreDDD.ApplicationLayer.Models;
using StoreDDD.ApplicationLayer.Services;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainCore.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreDDD.WebApi.Controllers
{
    /// <summary>
    /// Class CustomerController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/customers")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBusHandler">The command bus handler.</param>
        public CustomerController(ICustomerService customerService, INotificationHandler<DomainNotification> notificationHandler,
            ICommandDispatcher commandBusHandler) : base(notificationHandler, commandBusHandler)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// check email is available.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("email/{email}")]
        public IActionResult IsEmailAvailable(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) return BadRequest(new { Errors = "Email is required" });

                var result = _customerService.IsEmailAvailable(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest(new { Errors = "Customer id is required" });

                var result = _customerService.GetCustomerById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Gets the purchases history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{customerId}/purchases")]
        public IActionResult GetPurchasesHistory(Guid customerId)
        {
            try
            {
                if (customerId == Guid.Empty) return BadRequest(new { Errors = "Customer id is required" });

                var result = _customerService.GetCustomerPurchaseHistory(customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddCustomer([FromBody] AddNewCustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _customerService.Add(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPatch]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _customerService.Update(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _customerService.Remove(id);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }
    }
}