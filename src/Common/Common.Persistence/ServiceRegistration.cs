using Common.Persistence.Entities;
using Common.Persistence.Repositories;
using Common.Persistence.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Common.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            var serviceSettings = configuration.GetSection(nameof(ServiceSettings)) as ServiceSettings;

            services.AddSingleton(serviceProvider =>
            {
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)) as MongoDbSettings;
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });

            return services;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName)
            where T : Entity
        {
            services.AddSingleton<IRepository<T>>(serviceProvider =>
            {
                var database = serviceProvider.GetService<IMongoDatabase>();

                return new MongoRepository<T>(database, collectionName);
            });

            return services;
        }
    }
}
