﻿namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryGetAllUseCase : IInMemoryGetAllIUseCase<ItemDto>
    {
        private readonly IInMemoryData<ItemDto, UpdateItemDTO> _inMemoryData;

        public InMemoryGetAllUseCase(IInMemoryData<ItemDto, UpdateItemDTO> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute()
        {
            return Results.Ok(_inMemoryData.GetAllData());
        }
    }
}
