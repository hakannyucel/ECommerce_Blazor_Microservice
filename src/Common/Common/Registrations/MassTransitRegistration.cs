using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Registrations
{
    public static class MassTransitRegistration
    {
        public static IServiceCollection AddMassTransitEventBus(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumers(assembly);
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], "/", h =>
                    {
                        h.Username(configuration["RabbitMQ:Username"]);
                        h.Password(configuration["RabbitMQ:Password"]);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService();

            return services;
        }
    }
}
