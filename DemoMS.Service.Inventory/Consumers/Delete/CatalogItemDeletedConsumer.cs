namespace DemoMS.Service.Inventory.Consumers.Delete
{
    public class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeleted>
    {
        private readonly IDeleteDataUseCase<CatalogItem> _deleteDataUseCase;
        private readonly IGetDataByIDUseCase<CatalogItem> _getDataByIDUseCase;

        public CatalogItemDeletedConsumer(IDeleteDataUseCase<CatalogItem> deleteDataUseCase, IGetDataByIDUseCase<CatalogItem> getDataByIDUseCase)
        {
            _deleteDataUseCase = deleteDataUseCase;
            _getDataByIDUseCase = getDataByIDUseCase;
        }
        public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
        {
            var message = context.Message;

            var item = await _getDataByIDUseCase.ExecuteAsync(message.ItemId);

            if (item != null)
            {
                return;
            }

            await _deleteDataUseCase.ExecuteAsync(item.Id);
        }
    }
}
