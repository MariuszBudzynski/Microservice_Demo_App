namespace DemoMS.Service.Inventory.Consumers.Create
{
    public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
    {
        private readonly IAddDataUseCase<CatalogItem> _addDataUseCase;
        private readonly IGetDataByIDUseCase<CatalogItem> _getDataByIDUseCase;

        public CatalogItemCreatedConsumer(IAddDataUseCase<CatalogItem> addDataUseCase, IGetDataByIDUseCase<CatalogItem> getDataByIDUseCase)
        {
            _addDataUseCase = addDataUseCase;
            _getDataByIDUseCase = getDataByIDUseCase;
        }

        public async Task Consume(ConsumeContext<CatalogItemCreated> context)
        {
            var message = context.Message;

            var item = await _getDataByIDUseCase.ExecuteAsync(message.ItemId);

            if (item != null)
            {
                return;
            }

            await _addDataUseCase.ExecuteAsync(message
                                 .Mapp<CatalogItemCreated, CatalogItem>(x =>
                                    new()
                                    {
                                        Id = x.ItemId,
                                        Name = x.Name,
                                        Description = x.Description
                                    }));
        }

    }
}
