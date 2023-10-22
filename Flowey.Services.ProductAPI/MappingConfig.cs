using AutoMapper;
using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Services.ProductAPI.Models;

namespace Flowey.Services.ProductAPI;

public static class MappingConfigExtensions
{
    public static IServiceCollection AddMappingConfig(this IServiceCollection serviceCollection,
        Action<IMapperConfigurationExpression> config)
    {
        var mapping = new MapperConfiguration(config).CreateMapper();
        serviceCollection.AddSingleton(mapping);
        return serviceCollection;
    }
    
    public static void RegisterMaps(IMapperConfigurationExpression expression)
    {
        expression
            .CreateMap<ProductDto, Product>()
            .ReverseMap();
    }
}