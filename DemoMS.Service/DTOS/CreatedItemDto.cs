using System.ComponentModel.DataAnnotations;

namespace DemoMS.Service.DTOS
{
    public record CreatedItemDto(string Name,string Description, decimal Price);
}
