using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using System;

namespace StoreDDD.DomainCore.Commands
{
    /// <summary>
    /// Class Command.
    /// </summary>
    public abstract class Command : IRequest
    {
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        [JsonIgnore]
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the validation result.
        /// </summary>
        /// <value>The validation result.</value>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public abstract bool IsValid();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        protected Command()
        {
            MessageType = GetType().Name;
        }
    }
}
