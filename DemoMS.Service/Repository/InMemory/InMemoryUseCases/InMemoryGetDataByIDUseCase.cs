using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interfaces;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryGetDataByIDUseCase : IInMemoryGetDataByIDUseCase<ItemDto>
    {
        private readonly IInMemoryData<ItemDto, UpdateItemDTO> _inMemoryData;

        public InMemoryGetDataByIDUseCase(IInMemoryData<ItemDto, UpdateItemDTO> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(Guid id)
        {
            var data = _inMemoryData.GetDataByID(id);
            if (data == null)
            {
                return Results.NotFound("Item not found");
            }
            return Results.Ok(data);
        }
    }
}
