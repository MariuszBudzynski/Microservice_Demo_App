using DemoMS.Service.DTOS;
using DemoMS.Service.Repository.DatabaseRepository_MongoDB.Entities;

namespace DemoMS.Service.Extensions
{
    public static class Extensions
    {
        public static ItemDto ItemToItemDTO(this Item item)
        {
            return new ItemDto(item.Id,item.Name,item.Description,item.Price,item.CreatedDate);
        }

        public static Item CreatedItemDtoToItem(this CreatedItemDto createdItemDto)
        {
            return new Item()
            {
                Name = createdItemDto.Name,
                Description = createdItemDto.Description,
                Price = createdItemDto.Price,
                CreatedDate = DateTimeOffset.Now
            };
        }

        public static Item UpdateItemDtoToItem(this UpdateItemDTO createdItemDto,Guid id)
        {
            return new Item()
            {
                Id = id,
                Name = createdItemDto.Name,
                Description = createdItemDto.Description,
                Price = createdItemDto.Price,
                CreatedDate = DateTimeOffset.Now
            };
        }
    }
}
