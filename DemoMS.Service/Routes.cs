namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<Item> getAllDataUseCase, Response responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(getAllDataUseCase);
            });

            app.MapGet("/items/{id}", async (Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase, Response responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id, getDataByIDUseCase);
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase,
                Response responseHandler) =>
            {
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(item, addDataUseCase);
                }

                else return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                      IUpdateDataUseCase<Item> updateDataUseCase, Response responseHandler) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                    return await responseHandler.ReturnResultAsync(id, item, updateDataUseCase);
                }
                else return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IDeleteDataUseCase<Item> deleteDataUseCase, Response responseHandler) =>
            {
                return await responseHandler.ReturnResultAsync(id, deleteDataUseCase);
            });
        }
    }
}
