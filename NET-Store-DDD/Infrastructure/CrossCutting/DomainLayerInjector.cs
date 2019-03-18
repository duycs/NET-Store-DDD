using StoreDDD.DomainCore.Commands;
using StoreDDD.DomainCore.Events;
using StoreDDD.DomainCore.Notification;
using StoreDDD.DomainLayer.AggregatesModels.Customers.CommandHandlers;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Customers.EventHandlers;
using StoreDDD.DomainLayer.AggregatesModels.Customers.Events;
using StoreDDD.DomainLayer.AggregatesModels.Products.CommandHandlers;
using StoreDDD.DomainLayer.AggregatesModels.Products.Commands;
using StoreDDD.DomainLayer.AggregatesModels.Products.Events;
using StoreDDD.DomainLayer.Services.Checkout;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StoreDDD.Infrastructure.CrossCutting
{
    /// <summary>
    /// Class DomainLayerInjector.
    /// </summary>
    public class DomainLayerInjector
    {
        /// <summary>
        /// Registers the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            //Distributed Interface Install
    
            // Domain Bus (Mediator)
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerCreatedEvent>, DomainEventHandler<CustomerCreatedEvent>>();
            services.AddScoped<INotificationHandler<CustomerCreatedEvent>, CustomerCreatedEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, DomainEventHandler<CustomerUpdatedEvent>>();
            services.AddScoped<INotificationHandler<ProductCreatedEvent>, DomainEventHandler<ProductCreatedEvent>>();
            services.AddScoped<INotificationHandler<CustomerCheckOutEvent>, CustomerCheckOutEventHandler>();
            services.AddScoped<INotificationHandler<CustomerCheckOutEvent>, DomainEventHandler<CustomerCheckOutEvent>>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand>, ProductCommandHandler>();

            // Domain - Services
            services.AddTransient<CheckoutService>();
        }
    }
}