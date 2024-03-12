using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.UseCases;
using DemoMS.Service.Repository.InMemory.UseCases.Interfaces;

namespace DemoMS.Service
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //in memory
            services.AddScoped<IInMemoryData<ItemDto>,InMemoryData>();
            services.AddScoped<IInMemoryGetAllIUseCase<ItemDto>, InMemoryGetAllIUseCase>();
            
        }
    }
}
