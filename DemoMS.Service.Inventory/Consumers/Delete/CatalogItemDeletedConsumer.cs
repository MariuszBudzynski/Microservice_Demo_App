namespace DemoMS.Service.Inventory.Consumers.Delete
{
    public class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeleted>
    {
        private readonly IDeleteDataUseCase<CatalogItem> _deleteCatalogItemUseCase;
        private readonly IGetDataByIDUseCase<CatalogItem> _getCatalogItemByIDUseCase;
        private readonly IDeleteDataUseCase<InventoryItem> _deleteInventoryItemUseCase;
        private readonly IGetAllDataUseCase<InventoryItem> _getAllInventoryItemsUseCase;

        public CatalogItemDeletedConsumer(IDeleteDataUseCase<CatalogItem> deleteCatalogItemUseCase,
                                        IGetDataByIDUseCase<CatalogItem> getCatalogItemByIDUseCase,
                                        IDeleteDataUseCase<InventoryItem> deleteInventoryItemUseCase,
                                        IGetAllDataUseCase<InventoryItem> getAllInventoryItemsUseCase)
        {
            _deleteCatalogItemUseCase = deleteCatalogItemUseCase;
            _getCatalogItemByIDUseCase = getCatalogItemByIDUseCase;
            _deleteInventoryItemUseCase = deleteInventoryItemUseCase;
            _getAllInventoryItemsUseCase = getAllInventoryItemsUseCase;
        }
        public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
        {
            var message = context.Message;

            var catalogItem = await _getCatalogItemByIDUseCase.ExecuteAsync(message.ItemId);

            var inventoryItem = (await _getAllInventoryItemsUseCase.ExecuteAsync()).FirstOrDefault(x=>x.CatalogItemId == message.ItemId);

            if (catalogItem == null)
            {
                return;
            }

            if (inventoryItem != null)
            {
                await _deleteInventoryItemUseCase.ExecuteAsync(inventoryItem.Id);
            }

            await _deleteCatalogItemUseCase.ExecuteAsync(catalogItem.Id);
        }
    }
}
