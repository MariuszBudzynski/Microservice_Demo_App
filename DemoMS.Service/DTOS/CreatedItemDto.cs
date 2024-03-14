using System.ComponentModel.DataAnnotations;

namespace DemoMS.Service.DTOS
{
    public record CreatedItemDto([Required]string Name,string Description, [Range(0, 1000)] decimal price);
}
