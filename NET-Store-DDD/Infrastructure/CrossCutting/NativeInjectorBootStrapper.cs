using Microsoft.Extensions.DependencyInjection;

namespace StoreDDD.Infrastructure.CrossCutting
{
    /// <summary>
    /// Class NativeInjectorBootStrapper.
    /// </summary>
    public class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Registers the specified services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void Register(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            ApplicationLayerInjector.Register(services);
            DomainLayerInjector.Register(services);
            InfrastructureLayerInjector.Register(services);
        }
    }
}
