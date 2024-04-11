namespace DemoMS.Service.Inventory.Helpers
{
    public class InventoryItemDTOHelper
    {
        public async Task<InventoryItemDTO> CreateInventoryItemDTOAsync(CatalogItem catalogItem, InventoryItem inventoryItems)
        {
            return await Task.FromResult(new InventoryItemDTO(
                catalogItem.Id,
                catalogItem.Name,
                catalogItem.Description,
                inventoryItems.Quantity,
                inventoryItems.AcquiredDate
            ));
        }
    }
}
