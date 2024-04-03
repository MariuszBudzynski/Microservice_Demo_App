namespace DemoMS.Service.Inventory.DTOS
{
    public record InventoryItemDTO(Guid CatalogItemId,string Name,string Description,int Quantity,DateTimeOffset Acquired);
}
