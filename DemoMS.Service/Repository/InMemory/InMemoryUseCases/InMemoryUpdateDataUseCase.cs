using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryUpdateDataUseCase : IInMemoryUpdateDataUseCase<ItemDto>
    {
        private readonly IInMemoryData<ItemDto> _inMemoryData;

        public InMemoryUpdateDataUseCase(IInMemoryData<ItemDto> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(ItemDto item)
        {
            var data = _inMemoryData.GetDataByID(item.Id);

            if (data == null)
            {
                return Results.NotFound(404);
            }
            else
            {
                _inMemoryData.UpdataData(item);
                return Results.NoContent();
            }

        }
    }
}
