using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;
using DemoMS.Service.Repository.InMemory.InMemoryUseCases.Interfaces;

namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryDeleteDataUseCase : IInMemoryDeleteDataUseCase<ItemDto>
    {
        private readonly IInMemoryData<ItemDto> _inMemoryData;

        public InMemoryDeleteDataUseCase(IInMemoryData<ItemDto> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(Guid id)
        {
            var data = _inMemoryData.GetDataByID(id);

            if (data == null)
            {
                return Results.NotFound("No item found");
            }
            else
            {
                _inMemoryData.DeleteData(id);
                return Results.Ok();
            }

        }
    }
}
