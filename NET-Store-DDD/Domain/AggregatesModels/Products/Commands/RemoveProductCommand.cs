using System;
using FluentValidation;
using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Products.Validations;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Commands
{
    /// <summary>
    /// Class RemoveCustomerCommand.
    /// </summary>
    public class RemoveProductCommand : ProductCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public RemoveProductCommand(Guid id)
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
            ValidationResult = new RemoveProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
