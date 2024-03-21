namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryUpdateDataUseCase : IInMemoryUpdateDataUseCase<UpdateItemDTO>
    {
        private readonly IInMemoryData<ItemDto, UpdateItemDTO> _inMemoryData;

        public InMemoryUpdateDataUseCase(IInMemoryData<ItemDto, UpdateItemDTO> inMemoryData)
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
                _inMemoryData.UpdateData(id, item );
                return Results.NoContent();
            }
        }

    }
}
