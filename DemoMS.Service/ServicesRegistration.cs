using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemoryRepository;

namespace DemoMS.Service
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<InMemoryData<ItemDto>>();
        }
    }
}
