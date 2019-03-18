using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Products.Specification
{
    /// <summary>
    /// Class ProductIsInStockSpec. This class cannot be inherited.
    /// </summary>
    public sealed class ProductIsInStockSpec : SpecificationBase<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductIsInStockSpec"/> class.
        /// </summary>
        /// <param name="productCart">The product cart.</param>
        public ProductIsInStockSpec(CartProduct productCart)
            : base(product => product.Id == productCart.ProductId && product.IsActive && product.Quantity >= productCart.Quantity)
        {
        }
    }
}
