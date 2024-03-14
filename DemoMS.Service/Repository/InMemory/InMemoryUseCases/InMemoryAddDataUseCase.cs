using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryAddDataUseCase : IInMemoryAddDataUseCase<CreatedItemDto>
    {
        private readonly IInMemoryData<ItemDto> _inMemoryData;

        public InMemoryAddDataUseCase(IInMemoryData<ItemDto> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(CreatedItemDto data)
        {
            var newItem = new ItemDto(Guid.NewGuid(),data.Name,data.Description,data.price,DateTime.UtcNow);
           _inMemoryData.AddtData(newItem);
           return Results.Created();
        }
    }
}
