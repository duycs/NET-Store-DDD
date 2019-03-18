using System;
using StoreDDD.ApplicationLayer.Models;
using StoreDDD.ApplicationLayer.Services;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainCore.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace StoreDDD.WebApi.Controllers
{
    /// <summary>
    /// Class ProductController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBusHandler">The command bus handler.</param>
        public ProductController(IProductService productService, INotificationHandler<DomainNotification> notificationHandler,
            ICommandDispatcher commandBusHandler) : base(notificationHandler, commandBusHandler)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest(new { Errors = "Product id is required" });

                var result = _productService.GetProductById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var result = _productService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult AddProduct([FromBody] AddNewProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _productService.Add(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _productService.Update(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult UpdateProductWithoutCode([FromBody] UpdateProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Errors = ModelState });

                _productService.Update(model);

                if (Errors.Any()) return BadRequest(new { Errors });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest(new { Errors = "Product id is required" });

                _productService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
        }
    }
}