namespace DemoMS.Service.Inventory
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            //app.MapGet("/items", async (IGetDataByIDUseCase<InventoryItem> getAllDataUseCase,Guid id) =>
            //{
            //    return  await getAllDataUseCase.ExecuteAsync(x => x.UserId == id);
            //});
        }
    }
}
