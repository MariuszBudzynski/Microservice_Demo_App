using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;

namespace DemoMS.Service
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MongoDBContext>();

        }
    }
}
