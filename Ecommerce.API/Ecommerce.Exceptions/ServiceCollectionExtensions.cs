using Ecommerce.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Exceptions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<ExceptionMiddleware>();
            return serviceCollection;
        }
    }
}
