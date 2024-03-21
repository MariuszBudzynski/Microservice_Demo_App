namespace DemoMS.Service.Inventory.DTOS
{
    public record InventoryItemDTO(Guid CatalogItemId,int Quantity,DateTimeOffset Acquired);
}
