namespace DemoMS.Service.Inventory.Clients.Interfaces
{
    public interface ICatalogClient
    {
        Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemsAsync();
    }
}