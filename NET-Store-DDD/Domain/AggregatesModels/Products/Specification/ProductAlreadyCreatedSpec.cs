using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Specification
{
    /// <summary>
    /// Class ProductAlreadyCreatedSpec. This class cannot be inherited.
    /// </summary>
    public sealed class ProductAlreadyCreatedSpec : SpecificationBase<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAlreadyCreatedSpec" /> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public ProductAlreadyCreatedSpec(string code) : base(c => c.Code == code)
        {
        }
    }
}
