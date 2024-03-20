using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using DemoMS.Service.Catalog.Configuration;

namespace DemoMS.Service
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            var databaseConfiguration = new DatabaseConfiguration(configuration);
            var connectionString = databaseConfiguration.GetConnectionString();
            var (collectionName, databaseName) = databaseConfiguration.GetDatabaseSettings();

            // Mongo DB conversion to redable format
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            //configuring MongoDB to use the connection string inside the appsettings
            services.AddScoped(provider =>
            {
                var context = new MongoDBContext<Item>(connectionString, collectionName, databaseName);
                return context;
            });


            services.AddScoped<IMongoDBRepository<Item>,MongoDBRepository<Item>>();
            services.AddScoped<IAddDataUseCase<Item>, AddDataUseCase<Item>>();
            services.AddScoped<IGetDataByIDUseCase, GetDataByIDUseCase<Item>>();
            services.AddScoped<IGetAllDataUseCase, GetAllDataUseCase<Item>>();
            services.AddScoped<IUpdateDataUseCase<Item>, UpdateDataUseCase<Item>>();
            services.AddScoped<IDeleteDataUseCase, DeleteDataUseCase<Item>>();

        }
    }
}
