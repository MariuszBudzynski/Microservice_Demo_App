namespace DemoMS.Service.Inventory.Clients
{
    public class CatalogClient : ICatalogClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CatalogClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemsAsync()
        {
            var catalogItemsEndpoint = _configuration.GetValue<string>("Endpoints:CatalogItemsEndpoint");

            return await _httpClient.GetFromJsonAsync<IReadOnlyCollection<CatalogItemDto>>(catalogItemsEndpoint);
        }
    }
}
