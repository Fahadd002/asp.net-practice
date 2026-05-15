using Microsoft.Extensions.DependencyInjection;

namespace Demo.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractureDependency(this IServiceCollection services)
        {
            // Register your application services here
            return services;
        }
    }
}
