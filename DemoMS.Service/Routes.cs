namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<Item> getAllDataUseCase) =>
            {
                return await getAllDataUseCase.ExecuteAsync();
            });

            app.MapGet("/items/{id}", async (Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase) =>
            {
                return await getDataByIDUseCase.ExecuteAsync(id);
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase) =>
            {
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                   return await addDataUseCase.ExecuteAsync(item.CreatedItemDtoToItem());
                } 
                
                else return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                      IUpdateDataUseCase<Item> updateDataUseCase) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                   return await updateDataUseCase.ExecuteAsync(item.UpdateItemDtoToItem(id),id);
                }
                
                else  return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IDeleteDataUseCase deleteDataUseCase) =>
            {
                return await deleteDataUseCase.ExecuteAsync(id);
            });
        }
    }
}
