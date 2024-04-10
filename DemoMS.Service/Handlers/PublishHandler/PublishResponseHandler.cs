namespace DemoMS.Service.Catalog.Handlers.PublishEndpointHandler
{
    public class PublishResponseHandler
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishResponseHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishCatalogItemUpdatedAsync(Item item)
        {
            var itemToPublish = item.Mapp<Item, CatalogItemUpdated>(x => new(item.Id, item.Name, item.Description));
            await _publishEndpoint.Publish(itemToPublish);
        }

        public async Task PublishCatalogItemDeletedAsync(Item item)
        {
            var itemToPublish = item.Mapp<Item, CatalogItemDeleted>(x => new(item.Id));
            await _publishEndpoint.Publish(itemToPublish);
        }

        public async Task PublishCatalogItemCreatedAsync(Item item)
        {
            var itemToPublish = item.Mapp<Item, CatalogItemCreated>(x => new(item.Id, item.Name, item.Description));
            await _publishEndpoint.Publish(itemToPublish);
        }
    }
}
