using System;
using System.Text.RegularExpressions;
using FluentValidation;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Commands;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Validations
{
    /// <summary>
    /// Class UpdateCustomerCommandValidator.
    /// </summary>
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommandValidator" /> class.
        /// </summary>
        public UpdateCustomerCommandValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty().WithMessage("Customer id is required");
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("The first name is required");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("The last name is required");
        }
    }
}
