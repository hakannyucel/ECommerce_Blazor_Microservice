using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
