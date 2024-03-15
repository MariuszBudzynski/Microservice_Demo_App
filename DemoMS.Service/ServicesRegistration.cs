using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Repository.Interfaces;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.UseCases.Interfaces;

namespace DemoMS.Service
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MongoDBContext>();
            services.AddScoped<IMongoDBRepository<Item>,MongoDBRepository>();
            services.AddScoped<IAddDataUseCase<Item>, AddDataUseCase>();
            services.AddScoped<IGetDataByIDUseCase, GetDataByIDUseCase>();
            services.AddScoped<IGetAllDataUseCase, GetAllDataUseCase>();
            services.AddScoped<IUpdateDataUseCase<Item>, UpdateDataUseCase>();
            services.AddScoped<IDeleteDataUseCase, DeleteDataUseCase>();

        }
    }
}
