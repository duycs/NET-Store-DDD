using FluentValidation;
using StoreDDD.DomainCore.Commands;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Validations
{
    /// <summary>
    /// Class RemoveCustomerCommandValidator.
    /// </summary>
    public class CommandValidator : AbstractValidator<Command>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerCommandValidator" /> class.
        /// </summary>
        public CommandValidator()
        {
            //RuleFor(x => x.Id).NotEmpty().WithMessage("id is required");
        }
    }
}
