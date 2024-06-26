﻿namespace DemoMS.Service.Inventory
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (Guid id, IReturnResponse response) =>
            {
                return await response.ReturnResultAsync(id);
            });


            app.MapPut("/add-item", async (IValidator<GrantItemsDTO> validator, GrantItemsDTO grantItemsDTO, IReturnResponse response) =>
            {
                var validation = await validator.ValidateAsync(grantItemsDTO);

                if (validation.IsValid)
                {
                    return await response.ReturnResultAsync(grantItemsDTO);
                }

                else return Results.ValidationProblem(validation.ToDictionary());
            });
        }
    }
}
