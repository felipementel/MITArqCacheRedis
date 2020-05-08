using AutoMapper;

namespace Aplicacao.Application.AutoMapperConfigs
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig() { }

        public static MapperConfiguration RegisterMappings() =>
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClienteProfile());
            });
    }
}