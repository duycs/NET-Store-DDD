using AutoMapper;
using StoreDDD.ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace StoreDDD.Infrastructure.CrossCutting
{
    /// <summary>
    /// Class ApplicationLayerInjector.
    /// </summary>
    public class ApplicationLayerInjector
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            //Application
            //services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
        }
    }
}