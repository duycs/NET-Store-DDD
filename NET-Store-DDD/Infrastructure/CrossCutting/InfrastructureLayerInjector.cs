using StoreDDD.DomainCore.Repository;
using StoreDDD.DomainCore.UnitOfWork;
using StoreDDD.DomainLayer.AggregatesModels.Carts.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Repository;
using StoreDDD.DomainLayer.AggregatesModels.Products.Repository;
using StoreDDD.Infrastructure.Components.Mail;
using StoreDDD.Infrastructure.Context;
using StoreDDD.Infrastructure.Repositories;
using StoreDDD.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace StoreDDD.Infrastructure.CrossCutting
{
    /// <summary>
    /// Class InfrastructureLayerInjector.
    /// </summary>
    public class InfrastructureLayerInjector
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            // Infra - Data
            services.AddDbContext<StoreContext>();
            services.AddDbContext<EventStoreContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Infra - repository
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDomainEventRepository, DomainEventRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            //Infra  - services
            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}