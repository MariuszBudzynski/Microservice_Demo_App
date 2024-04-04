namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IReturnResponse responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync();
            });

            app.MapGet("/items/{id}", async (Guid id, IReturnResponse responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id);
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item,
                IReturnResponse responseHandler) =>
            {
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(item);
                }

                else return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                       IReturnResponse responseHandler) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(id, item);
                }
                else return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IReturnResponse responseHandler) =>
            {

                return await responseHandler.ReturnResultAfterDeleteAsync(id);
            });
        }
    }
}
