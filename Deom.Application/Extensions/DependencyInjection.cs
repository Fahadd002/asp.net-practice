using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastacture.Extensions
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
