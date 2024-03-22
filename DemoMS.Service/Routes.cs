namespace DemoMS.Service
{
    public static class Routes
    {
        public static void ConfigureRoutes(WebApplication app)
        {
            app.MapGet("/items", async (IGetAllDataUseCase<Item> getAllDataUseCase,MappData mapper) =>
            {
                var items = await getAllDataUseCase.ExecuteAsync();
                return Results.Ok(mapper.MappToItesmDto(items));
            });

            app.MapGet("/items/{id}", async (Guid id,IGetDataByIDUseCase<Item> getDataByIDUseCase, MappData mapper) =>
            {
                var data = await getDataByIDUseCase.ExecuteAsync(id);
                if (data != null)
                {
                    var item = mapper.MappToItemDto(data);
                    return Results.Ok(item);
                }
                else return Results.NotFound("No data found");
            });

            app.MapPost("/items", async (IValidator<CreatedItemDto> validator, CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase,MappData mapper) =>
            {
                var validation = validator.Validate(item);

                if (validation.IsValid)
                {
                    var mappedItem = mapper.MappToItem(item);
                    await addDataUseCase.ExecuteAsync(mappedItem);
                    return Results.Created();
                } 
                
                else return Results.ValidationProblem(validation.ToDictionary());

            });

            app.MapPut("/items/{id}", async (IValidator<UpdateItemDTO> validator, Guid id, UpdateItemDTO item,
                                      IUpdateDataUseCase<Item> updateDataUseCase,MappData mapper) =>
            {
                var validation = validator.Validate(item);
                if (validation.IsValid)
                {
                    var mappedItem = mapper.MappToItem(item, id);
                    var data =  await updateDataUseCase.ExecuteAsync(mappedItem,id);
                    return data == null ? Results.NotFound("No item found") : Results.NoContent();
                }
                
                else  return Results.ValidationProblem(validation.ToDictionary());
            });

            app.MapDelete("/items/{id}", async (Guid id, IDeleteDataUseCase<Item> deleteDataUseCase) =>
            {
                var data =  await deleteDataUseCase.ExecuteAsync(id);
                return data == null ?  Results.NotFound("No item found") : Results.Ok();
            });
        }
    }
}
