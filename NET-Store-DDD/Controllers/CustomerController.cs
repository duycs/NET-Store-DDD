using System;
using System.Linq;
using StoreDDD.ApplicationLayer.Models;
using StoreDDD.ApplicationLayer.Services;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainCore.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
        private readonly IConfiguration _configuration;
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController" /> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        /// <param name="notificationHandler">The notification handler.</param>
        /// <param name="commandBusHandler">The command bus handler.</param>
        public CustomerController(IConfiguration configuration, ICustomerService customerService, INotificationHandler<DomainNotification> notificationHandler,
            ICommandDispatcher commandBusHandler) : base(notificationHandler, commandBusHandler)
        {
            _configuration = configuration;
            _customerService = customerService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromHeader]string email, [FromHeader]string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return BadRequest(new { Errors = "UserName or Password is not empty" });

                var customer = _customerService.GetCustomerByEmailAndPassword(email, password);
                if (customer == null)
                    return Unauthorized();

                var loginInfo = GetLoginInfo(customer);
                if (loginInfo == null)
                    return Unauthorized();

                return Ok(loginInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Errors = ex.Message });
            }
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

        public class LoginInfo
        {
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public CustomerDto User { get; set; }
            public object[] Perms { get; set; }
        }

        private LoginInfo GetLoginInfo(CustomerDto customer)
        {
            // TODO: check perms
            var perms = new object[] { new { Allows = "read", Resources = "all tables" } };

            if (perms == null)
                return null;

            var tokenString = BuildToken(customer);

            var loginInfo = new LoginInfo
            {
                AccessToken = tokenString,
                TokenType = "jwt",
                User = customer,
                Perms = perms
            };

            return loginInfo;
        }

        private string BuildToken(CustomerDto customer)
        {
            var claims = new[]
            {
                //name id is phone
                new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                //other info store in sub
                new Claim(JwtRegisteredClaimNames.Sub, JsonConvert.SerializeObject(customer)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(DateTime.Now).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}