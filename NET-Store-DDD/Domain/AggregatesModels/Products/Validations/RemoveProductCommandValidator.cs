using FluentValidation;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Validations
{
    /// <summary>
    /// Class RemoveProductCommandValidator.
    /// </summary>
    public class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveProductCommandValidator" /> class.
        /// </summary>
        public RemoveProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("id is required");
        }
    }
}
