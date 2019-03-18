using FluentValidation;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Validations
{
    /// <summary>
    /// Class CreateProductCommandValidator.
    /// </summary>
    public class CreateProductCommandValidator :  AbstractValidator<CreateProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommandValidator"/> class.
        /// </summary>
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("The product name is required");
            RuleFor(product => product.Code).NotEmpty().WithMessage("The product code is required");
        }
    }
}
