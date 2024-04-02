namespace DemoMS.Service.Inventory
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            //app.MapGet("/items", async (IGetAllDataUseCase<InventoryItem> getAllDataUseCase, Guid id,Response response) =>
            //{
            //    return await response.ReturnResultAsync(getAllDataUseCase,id);
            //});


            //app.MapGet("/add-item", async (GrantItemsDTO grantItemsDTO , Response response,
            //            IGetDataByIDUseCase<InventoryItem> getDataByIDUseCase , IAddDataUseCase <InventoryItem> addDataUseCase,
            //            IUpdateDataUseCase<InventoryItem> updateDataUseCase) =>
            //{
            //    return await response.ReturnResultAsync(grantItemsDTO,getDataByIDUseCase,addDataUseCase,updateDataUseCase);
            //});
        }
    }
}
