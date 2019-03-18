using FluentValidation;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Commands;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Validations
{
    /// <summary>
    /// Class RemoveProductCommandValidator.
    /// </summary>
    public class RemoveCustomerCommandValidator : AbstractValidator<RemoveCustomerCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public RemoveCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Customer id is required");
        }
    }
}
