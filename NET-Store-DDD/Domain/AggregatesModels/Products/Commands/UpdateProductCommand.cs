using StoreDDD.DomainLayer.AggregatesModels.Products.Validations;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Commands
{
    /// <summary>
    /// Class CreateCustomerCommand.
    /// </summary>
    public sealed class UpdateProductCommand : ProductCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommand" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="code">The code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="cost">The cost.</param>
        public UpdateProductCommand(string name, string code, int quantity, decimal cost)
        {
            Name = name;
            Quantity = quantity;
            Cost = cost;
            Code = code;
        }

        public UpdateProductCommand(string name, int quantity, decimal cost)
        {
            Name = name;
            Quantity = quantity;
            Cost = cost;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
