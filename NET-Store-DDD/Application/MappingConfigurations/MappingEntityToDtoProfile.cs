using AutoMapper;
using StoreDDD.ApplicationLayer.DataTransferObjects;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Models;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Models;
using StoreDDD.DomainLayer.AggregatesModels.Products.Models;
using StoreDDD.DomainLayer.AggregatesModels.Purchases.Models;

namespace StoreDDD.ApplicationLayer.MappingConfigurations
{
    /// <summary>
    /// Class MappingEntityToDto.
    /// </summary>
    public class MappingEntityToDtoProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingEntityToDtoProfile" /> class.
        /// </summary>
        public MappingEntityToDtoProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartProduct, CartProductDto>();
            CreateMap<Purchase, CheckOutResultDto>()
                .ForMember(x => x.PurchaseId, options => options.MapFrom(x => x.Id));
        }
    }
}
