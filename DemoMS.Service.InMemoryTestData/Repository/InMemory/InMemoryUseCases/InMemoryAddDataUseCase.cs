namespace DemoMS.Service.Repository.InMemory.UseCases
{
    public class InMemoryAddDataUseCase : IInMemoryAddDataUseCase<CreatedItemDto>
    {
        private readonly IInMemoryData<ItemDto, UpdateItemDTO> _inMemoryData;

        public InMemoryAddDataUseCase(IInMemoryData<ItemDto, UpdateItemDTO> inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }

        public IResult Execute(CreatedItemDto data)
        {
            var newItem = new ItemDto(Guid.NewGuid(),data.Name,data.Description,data.Price, DateTimeOffset.UtcNow);
           _inMemoryData.AddData(newItem);
           return Results.Created();
        }
    }
}
