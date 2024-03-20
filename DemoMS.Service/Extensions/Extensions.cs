namespace DemoMS.Service.Extensions
{
    public static class Extensions
    {
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
