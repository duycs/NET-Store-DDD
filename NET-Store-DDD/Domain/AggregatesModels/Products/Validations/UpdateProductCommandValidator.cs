using FluentValidation;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Validations
{
    /// <summary>
    /// Class CreateProductCommandValidator.
    /// </summary>
    public class UpdateProductCommandValidator :  AbstractValidator<UpdateProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProductCommandValidator"/> class.
        /// </summary>
        public UpdateProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("The product name is required");
            RuleFor(product => product.Code).NotEmpty().WithMessage("The product code is required");
        }
    }
}
