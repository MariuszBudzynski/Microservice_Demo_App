using DemoMS.Service.DTOS;

namespace DemoMS.Service.Repository.InMemoryRepository
{
    public class InMemoryData<T> where T : class
    {
        public readonly List<ItemDto> itemDtos = new()
        {
            new ItemDto (Guid.NewGuid(),"Potion","Restores HP",5,DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(),"Antidote","Cures Poison",7,DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(),"Bronze sword","Deals some damage",20,DateTimeOffset.UtcNow),
        };
    }
}
