﻿using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interfaces;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;
using DemoMS.Service.Repository.InMemory.UseCases;
using DemoMS.Service.Repository.InMemory.UseCases.Interfaces;

namespace DemoMS.Service.Catalog.TestData
{
    public static class InMemoryServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IInMemoryData<ItemDto, UpdateItemDTO>, InMemoryData>();
            services.AddScoped<IInMemoryGetAllIUseCase<ItemDto>, InMemoryGetAllUseCase>();
            services.AddScoped<IInMemoryGetDataByIDUseCase<ItemDto>, InMemoryGetDataByIDUseCase>();
            services.AddScoped<IInMemoryAddDataUseCase<CreatedItemDto>, InMemoryAddDataUseCase>();
            services.AddScoped<IInMemoryDeleteDataUseCase<ItemDto>, InMemoryDeleteDataUseCase>();
            services.AddScoped<IInMemoryUpdateDataUseCase<UpdateItemDTO>, InMemoryUpdateDataUseCase>();

        }
    }
}
