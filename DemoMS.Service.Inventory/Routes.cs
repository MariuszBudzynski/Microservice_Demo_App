namespace DemoMS.Service.Inventory
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (Guid id, IResponse response) =>
            {
                return await response.ReturnResultAsync(id);
            });


            app.MapPut("/add-item", async (GrantItemsDTO grantItemsDTO, IResponse response) =>
            {
                return await response.ReturnResultAsync(grantItemsDTO);
            });
        }
    }
}
