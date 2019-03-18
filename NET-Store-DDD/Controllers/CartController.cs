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
    /// Class CartController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/carts")]
    public class CartController : ApiController
    {
        /// <summary>
        /// The cart service
        /// </summary>
        private readonly ICartService _cartService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController" /> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBusHandler">The command bus handler.</param>
        public CartController(ICartService cartService, INotificationHandler<DomainNotification> notificationHandler,
            ICommandDispatcher commandBusHandler) : base(notificationHandler, commandBusHandler)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Gets the by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(Guid customerId)
        {

            try
            {
                if (customerId == Guid.Empty) return BadRequest(new { Errors = "Customer id is required" });

                var result = _cartService.GetProductsInCartByCustomerId(customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Adds to cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddToCart([FromBody] AddProudctToCartViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _cartService.Add(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Removes the product from cart.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public IActionResult RemoveProductFromCart([FromBody] RemoveProductFromCartViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _cartService.Remove(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Removes the product from cart.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("checkout/customer/{customerId}")]
        public IActionResult Checkout(Guid customerId)
        {
            try
            {
                if (customerId == Guid.Empty) return BadRequest(new { Errors = "Customer id is required" });

                var result = _cartService.CheckOut(customerId);
                if (Errors.Any()) return BadRequest(new { Errors });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }
    }
}