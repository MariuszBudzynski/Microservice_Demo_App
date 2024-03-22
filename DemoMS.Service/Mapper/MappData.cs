using DemoMS.Service.Extensions;

namespace DemoMS.Service.Catalog.Mapper
{
    public class MappData
    {
        //private readonly IGetAllDataUseCase<Item> _getAllDataUseCase;
        //private readonly IGetDataByIDUseCase<Item> _getDataByIDUseCase;

        //public MappData(IGetAllDataUseCase<Item> getAllDataUseCase,IGetDataByIDUseCase<Item> getDataByIDUseCase)
        //{
        //    _getAllDataUseCase = getAllDataUseCase;
        //    _getDataByIDUseCase = getDataByIDUseCase;
        //}

        public IReadOnlyCollection<ItemDto> MappToItesmDto(IReadOnlyCollection<Item> dataTomapp)
        {
             return (dataTomapp.Select(x => x.ItemToItemDTO())).ToList();      
        }

        public  ItemDto MappToItemDto(Item item)
        {
            
            if (item == null)
            {
                return null;
            }
            else
            {
                return item.ItemToItemDTO();
            }
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
