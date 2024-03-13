using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.UseCases.Interfaces;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryGetAllUseCase : IInMemoryGetAllIUseCase<ItemDto>
    {
        private readonly IInMemoryData<ItemDto> _inMemoryData;

        public InMemoryGetAllUseCase(IInMemoryData<ItemDto> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        //public IEnumerable<ItemDto> Execute()
        //{
        //    return (_inMemoryData.GetAllData()).ToList();
        //}

        public IResult Execute()
        {
            // return (_inMemoryData.GetAllData()).ToList();
            return Results.Ok(_inMemoryData.GetAllData());
        }
    }
}
