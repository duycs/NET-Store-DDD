using System;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Validations;

namespace StoreDDD.DomainLayer.AggregatesModels.Customers.Commands
{
    /// <summary>
    /// Class RemoveCustomerCommand.
    /// </summary>
    public class RemoveCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommand" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
