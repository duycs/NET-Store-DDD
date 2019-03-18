using AutoMapper;

namespace StoreDDD.ApplicationLayer.MappingConfigurations
{
    /// <summary>
    /// Class AutoMapping.
    /// </summary>
    public class AutoMapping
    {
        /// <summary>
        /// Registers the mappings.
        /// </summary>
        /// <returns>MapperConfiguration.</returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingEntityToDtoProfile());
                cfg.AddProfile(new MappingViewModelToCommandProfile());
            });
        }
    }
}
