using AutoMapper;

namespace eFoodShop.Application.SeedWork.AutoMapper
{
    public static class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });
        }
    }
}