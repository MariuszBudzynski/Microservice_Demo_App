using DemoMS.Service.Catalog.ResponseHandler.Interfaces;

namespace DemoMS.Service.Catalog.ResponseHandler
{
    public class Response : IResponse
    {
        private readonly IAddDataUseCase<Item> _addDataUseCase;
        private readonly IUpdateDataUseCase<Item> _updateDataUseCase;
        private readonly IDeleteDataUseCase<Item> _deleteDataUseCase;
        private readonly IGetDataByIDUseCase<Item> _getDataByIDUseCase;
        private readonly IGetAllDataUseCase<Item> _getAllDataUseCase;

        public Response(
            IAddDataUseCase<Item> addDataUseCase,
            IUpdateDataUseCase<Item> updateDataUseCase,
            IDeleteDataUseCase<Item> deleteDataUseCase,
            IGetDataByIDUseCase<Item> getDataByIDUseCase,
            IGetAllDataUseCase<Item> getAllDataUseCase)
        {
            _addDataUseCase = addDataUseCase;
            _updateDataUseCase = updateDataUseCase;
            _deleteDataUseCase = deleteDataUseCase;
            _getDataByIDUseCase = getDataByIDUseCase;
            _getAllDataUseCase = getAllDataUseCase;
        }

        public async Task<IResult> ReturnResultAsync()
        {
            var items = (await _getAllDataUseCase.ExecuteAsync()).Select(x => x.Mapp<Item, ItemDto>(x => new(x.Id, x.Name, x.Description, x.Price, x.CreatedDate)));
            return Results.Ok(items);
        }

        public async Task<IResult> ReturnResultAsync(Guid id)
        {
            var data = (await _getDataByIDUseCase.ExecuteAsync(id)).Mapp<Item, ItemDto>(x => new(x.Id, x.Name, x.Description, x.Price, x.CreatedDate));
            if (data != null)
            {
                return Results.Ok(data);
            }
            else return Results.NotFound("No data found");
        }

        public async Task<IResult> ReturnResultAsync(CreatedItemDto item)
        {
            await _addDataUseCase.ExecuteAsync(item.Mapp<CreatedItemDto, Item>(x => new()
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = DateTimeOffset.Now
            }));
            return Results.Created();
        }

        public async Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item)
        {
            var data = await _updateDataUseCase.ExecuteAsync(item.Mapp<UpdateItemDTO, Item>(x => new()
            {
                Id = id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = DateTimeOffset.Now
            }), id);

            return data == null ? Results.NotFound("No item found") : Results.NoContent();
        }


        public async Task<IResult> ReturnResultAfterDeleteAsync(Guid id)
        {
            var data = await _deleteDataUseCase.ExecuteAsync(id);
            return data == null ? Results.NotFound("No item found") : Results.Ok();
        }
    }
}
