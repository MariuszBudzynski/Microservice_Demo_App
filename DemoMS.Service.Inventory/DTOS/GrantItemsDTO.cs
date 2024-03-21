namespace DemoMS.Service.Inventory.DTOS
{
    public record GrantItemsDTO(Guid UserId,Guid CatalogitemId,int Quantity);
}
