using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

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
                var context = new MongoDBContext(mongoConnectionString);
                return context;
            });

            //services.AddScoped<MongoDBContext>();
            services.AddScoped<IMongoDBRepository<Item>,MongoDBRepository>();
            services.AddScoped<IAddDataUseCase<Item>, AddDataUseCase>();
            services.AddScoped<IGetDataByIDUseCase, GetDataByIDUseCase>();
            services.AddScoped<IGetAllDataUseCase, GetAllDataUseCase>();
            services.AddScoped<IUpdateDataUseCase<Item>, UpdateDataUseCase>();
            services.AddScoped<IDeleteDataUseCase, DeleteDataUseCase>();

        }
    }
}
