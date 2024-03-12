using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;

namespace DemoMS.Service.Repository.InMemory.InMemoryRepository
{
    public class InMemoryData : IInMemoryData<ItemDto>
    {
        public static readonly List<ItemDto> itemDtos = new()
        {
            new ItemDto (Guid.NewGuid(),"Potion","Restores HP",5,DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(),"Antidote","Cures Poison",7,DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(),"Bronze sword","Deals some damage",20,DateTimeOffset.UtcNow),
        };

        public IEnumerable<ItemDto> GetAllData()
        {
            return itemDtos;
        }
    }
}
