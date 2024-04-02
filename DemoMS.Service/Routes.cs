namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<Item> getAllDataUseCase, [FromServices]Response responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(getAllDataUseCase);
            });

            app.MapGet("/items/{id}", async (Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase, [FromServices]Response responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id, getDataByIDUseCase);
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase,
                [FromServices] Response responseHandler) =>
            {
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(item, addDataUseCase);
                }

                else return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                      IUpdateDataUseCase<Item> updateDataUseCase, [FromServices] Response responseHandler) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(id, item, updateDataUseCase);
                }
                else return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IDeleteDataUseCase<Item> deleteDataUseCase, [FromServices] Response responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id, deleteDataUseCase);
            });
        }
    }
}
