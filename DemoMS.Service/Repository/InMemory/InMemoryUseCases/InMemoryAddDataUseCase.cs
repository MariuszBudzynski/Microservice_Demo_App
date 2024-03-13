using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryAddDataUseCase : IInMemoryAddDataUseCase<ItemDto>
    {
        private readonly IInMemoryData<ItemDto> _inMemoryData;

        public InMemoryAddDataUseCase(IInMemoryData<ItemDto> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(ItemDto data)
        {
           _inMemoryData.AddtData(data);
           return Results.Created();
        }
    }
}
