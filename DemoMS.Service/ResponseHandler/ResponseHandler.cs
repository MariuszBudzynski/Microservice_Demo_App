namespace DemoMS.Service.Catalog.ResponseHandler
{
    public class ResponseHandler
    {
        public async Task<IResult> ReturnResultAsync(IGetAllDataUseCase<Item> getAllDataUseCase, MappData mapper)
        {
            var items = await getAllDataUseCase.ExecuteAsync();
            return Results.Ok(mapper.MappToItesmDto(items));
        }

        public async Task<IResult> ReturnResultAsync(Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase, MappData mapper)
        {
            var data = await getDataByIDUseCase.ExecuteAsync(id);
            if (data != null)
            {
                var item = mapper.MappToItemDto(data);
                return Results.Ok(item);
            }
            else return Results.NotFound("No data found");
        }

        public async Task<IResult> ReturnResultAsync(CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase, MappData mapper)
        {
            var mappedItem = mapper.MappToItem(item);
            await addDataUseCase.ExecuteAsync(mappedItem);
            return Results.Created();
        }

        public async Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item,
                                   IUpdateDataUseCase<Item> updateDataUseCase, MappData mapper)
        {
            var mappedItem = mapper.MappToItem(item, id);
            var data = await updateDataUseCase.ExecuteAsync(mappedItem, id);
            return data == null ? Results.NotFound("No item found") : Results.NoContent();
        }

        public async Task<IResult> ReturnResultAsync(Guid id, IDeleteDataUseCase<Item> deleteDataUseCase)
        {
            var data = await deleteDataUseCase.ExecuteAsync(id);
            return data == null ? Results.NotFound("No item found") : Results.Ok();
        }
    }
}
