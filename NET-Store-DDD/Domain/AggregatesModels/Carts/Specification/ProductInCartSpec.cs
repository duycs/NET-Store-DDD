using StoreDDD.DomainCore.Specification;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;

namespace StoreDDD.DomainLayer.AggregatesModels.Carts.Specification
{
    /// <summary>
    /// Class ProductInCartSpec.
    /// </summary>
    public class ProductInCartSpec : SpecificationBase<CartProduct>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInCartSpec"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public ProductInCartSpec(Product product) : base(p => p.ProductId == product.Id)
        {
        }
    }
}
