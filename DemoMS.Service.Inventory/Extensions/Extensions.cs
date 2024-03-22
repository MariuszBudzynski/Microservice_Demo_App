namespace DemoMS.Service.Inventory
{
    public static class Extensions
    {
        public static InventoryItemDTO InventoryItemToInventoryItemDTO(this InventoryItem inventoryItem)
        {
           return new InventoryItemDTO(inventoryItem.CatalogItemId, inventoryItem.Quantity, inventoryItem.AcquiredDate);
        }
    }
}
