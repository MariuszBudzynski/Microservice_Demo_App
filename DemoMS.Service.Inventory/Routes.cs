namespace DemoMS.Service.Inventory
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<InventoryItem> getAllDataUseCase) =>
            {
                return await getAllDataUseCase.ExecuteAsync();
            });
        }
    }
}
