namespace DemoMS.Service.Catalog.Mapper
{
    public class MappData
    {
        public IReadOnlyCollection<ItemDto> MappToItesmDto(IReadOnlyCollection<Item> dataTomapp)
        {
             return (dataTomapp.Select(x => x.ItemToItemDTO())).ToList();      
        }

        public  ItemDto MappToItemDto(Item item)
        {  
                return item.ItemToItemDTO();
        }

        public Item MappToItem(CreatedItemDto dataTomapp)
        {
            return dataTomapp.CreatedItemDtoToItem();
        }

        public Item MappToItem(UpdateItemDTO dataTomapp,Guid id)
        {
            return dataTomapp.UpdateItemDtoToItem(id);
        }
    }
}
