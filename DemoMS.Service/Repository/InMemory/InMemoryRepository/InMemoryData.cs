using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.InMemory.InMemoryRepository.Interface;

namespace DemoMS.Service.Repository.InMemory.InMemoryRepository
{
    public class InMemoryData : IInMemoryData<ItemDto, UpdateItemDTO>
    {
        private static List<ItemDto> itemDtos = new()
        {
            new ItemDto (Guid.NewGuid(),"Potion","Restores HP",5,DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(),"Antidote","Cures Poison",7,DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(),"Bronze sword","Deals some damage",20,DateTimeOffset.UtcNow),
        };

        public IEnumerable<ItemDto> GetAllData()
        {
            return itemDtos;
        }

        public ItemDto GetDataByID(Guid id)
        {
            return itemDtos.FirstOrDefault(x => x.Id == id);
        }

        public void AddData(ItemDto data)
        {
            itemDtos.Add(data);
        }

        public void DeleteData(Guid id)
        {
            var dataToBeRemoved = GetDataByID(id);
            itemDtos.Remove(dataToBeRemoved);
        }

        public void UpdateData(Guid id, UpdateItemDTO item)
        {
            var itemToBeRemoved = GetDataByID(id);
            ItemDto updatedItemDto = new(itemToBeRemoved.Id, item.Name, item.Description, item.price, DateTimeOffset.UtcNow);

            itemDtos.Remove(itemToBeRemoved);
            itemDtos.Add(updatedItemDto);
        }
    }
}
