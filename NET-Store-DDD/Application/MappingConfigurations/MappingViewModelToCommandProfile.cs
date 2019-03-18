using AutoMapper;
using StoreDDD.ApplicationLayer.Models;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;

namespace StoreDDD.ApplicationLayer.MappingConfigurations
{
    /// <summary>
    /// Class MappingViewModelToCommandProfile.
    /// </summary>
    public class MappingViewModelToCommandProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingViewModelToCommandProfile"/> class.
        /// </summary>
        public MappingViewModelToCommandProfile()
        {
            //customers
            CreateMap<AddNewCustomerViewModel, CreateCustomerCommand>()
                .ConstructUsing(c => new CreateCustomerCommand(c.FirstName, c.LastName, c.Email, c.CountryId));
            CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.CustomerId, c.FirstName, c.LastName, c.CountryId));
            CreateMap<RemoveCustomerViewModel, RemoveCustomerCommand>()
               .ConstructUsing(c => new RemoveCustomerCommand(c.CustomerId));

            //products
            CreateMap<AddNewProductViewModel, CreateProductCommand>()
               .ConstructUsing(c => new CreateProductCommand(c.Name, c.Code, c.Quantity, c.Cost));
            CreateMap<UpdateProductViewModel, UpdateProductCommand>()
            .ConstructUsing(c => new UpdateProductCommand(c.Name, c.Code, c.Quantity, c.Cost));
        }
    }
}
