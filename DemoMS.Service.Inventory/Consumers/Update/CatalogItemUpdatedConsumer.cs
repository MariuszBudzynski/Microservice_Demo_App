namespace DemoMS.Service.Inventory.Consumers.Update
{
    public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemUpdated>
    {
        private readonly IGetDataByIDUseCase<CatalogItem> _getDataByIDUseCase;
        private readonly IUpdateDataUseCase<CatalogItem> _updateDataUseCase;
        private readonly IAddDataUseCase<CatalogItem> _addDataUseCase;

        public CatalogItemUpdatedConsumer(IGetDataByIDUseCase<CatalogItem> getDataByIDUseCase,
                                          IUpdateDataUseCase<CatalogItem> updateDataUseCase,
                                          IAddDataUseCase<CatalogItem> addDataUseCase)
        {
            _getDataByIDUseCase = getDataByIDUseCase;
            _updateDataUseCase = updateDataUseCase;
            _addDataUseCase = addDataUseCase;
        }

        public async Task Consume(ConsumeContext<CatalogItemUpdated> context)
        {
            var message = context.Message;

            var item = await _getDataByIDUseCase.ExecuteAsync(message.ItemId);

            var mappedItem = message.Mapp<CatalogItemUpdated, CatalogItem>(x => new()
            {
                Id = x.ItemId,
                Name = x.Name,
                Description = x.Description
            });

            if (item == null)
            {
                await _addDataUseCase.ExecuteAsync(mappedItem);
            }

            else
            {
                await _updateDataUseCase.ExecuteAsync(mappedItem, item.Id);
            }
        }
    }
}
