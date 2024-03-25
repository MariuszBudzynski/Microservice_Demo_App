namespace DemoMS.Service.Inventory
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<InventoryItem> getAllDataUseCase, Guid id,Response response) =>
            {
                return await response.ReturnResultAsync(getAllDataUseCase,id);
            });
        }
    }
}
