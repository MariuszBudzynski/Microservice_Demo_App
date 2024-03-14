using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;
using System.Security.Claims;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryUpdateDataUseCase : IInMemoryUpdateDataUseCase<UpdateItemDTO>
    {
        private readonly IInMemoryData<ItemDto> _inMemoryData;

        public InMemoryUpdateDataUseCase(IInMemoryData<ItemDto> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(Guid id, UpdateItemDTO item)
        {
            var data = _inMemoryData.GetDataByID(id);

            if (data == null)
            {
                return Results.NotFound("Item not found");
            }
            else
            {
                _inMemoryData.UpdataData(id, item );
                return Results.NoContent();
            }
        }

    }
}
