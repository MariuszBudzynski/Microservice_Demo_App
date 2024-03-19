using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using DemoMS.Service.DTOS;
using DemoMS.Service.Catalog.Repository.DatabaseRepository_MongoDB.Entities.Interfaces;

namespace DemoMS.Service
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services, string mongoConnectionString)
        {
            // Mongo DB conversion to redable format
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            //configuring MongoDB to use the connection string inside the appsettings
            services.AddScoped(provider =>
            {
                var context = new MongoDBContext<Item>(mongoConnectionString);
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
