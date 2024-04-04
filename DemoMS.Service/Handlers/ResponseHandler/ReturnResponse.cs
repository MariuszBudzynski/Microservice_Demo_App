namespace DemoMS.Service.Catalog.Handlers.ResponseHandler
{
    public class ReturnResponse : IReturnResponse
    {
        private readonly IAddDataUseCase<Item> _addDataUseCase;
        private readonly IUpdateDataUseCase<Item> _updateDataUseCase;
        private readonly IDeleteDataUseCase<Item> _deleteDataUseCase;
        private readonly IGetDataByIDUseCase<Item> _getDataByIDUseCase;
        private readonly IGetAllDataUseCase<Item> _getAllDataUseCase;
        private readonly PublishResponseHandler _publishEndpointHandler;

        public ReturnResponse(
            IAddDataUseCase<Item> addDataUseCase,
            IUpdateDataUseCase<Item> updateDataUseCase,
            IDeleteDataUseCase<Item> deleteDataUseCase,
            IGetDataByIDUseCase<Item> getDataByIDUseCase,
            IGetAllDataUseCase<Item> getAllDataUseCase,
            PublishResponseHandler publishEndpointHandler)
        {
            _addDataUseCase = addDataUseCase;
            _updateDataUseCase = updateDataUseCase;
            _deleteDataUseCase = deleteDataUseCase;
            _getDataByIDUseCase = getDataByIDUseCase;
            _getAllDataUseCase = getAllDataUseCase;
            _publishEndpointHandler = publishEndpointHandler;
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
            var newItem = item.Mapp<CreatedItemDto, Item>(x => new ()
            {
                Id = Guid.NewGuid(),
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                CreatedDate = DateTimeOffset.Now
            });

            await _addDataUseCase.ExecuteAsync(newItem);

            await _publishEndpointHandler.PublishCatalogItemCreatedAsync(newItem);

            return Results.Created();
        }

        public async Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item)
        {
            var newItem = item.Mapp<UpdateItemDTO, Item>(x => new()
            {
                Id = id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = DateTimeOffset.Now
            });

            var data = await _updateDataUseCase.ExecuteAsync(newItem,id);

            if (data == null)
            {
                return Results.NotFound("No item found");
            }
            else
            {
                await _publishEndpointHandler.PublishCatalogItemUpdatedAsync(newItem);
                return Results.NoContent();
            }
        }


        public async Task<IResult> ReturnResultAfterDeleteAsync(Guid id)
        {
            var data = await _deleteDataUseCase.ExecuteAsync(id);

            if (data == null)
            {
                return Results.NotFound("No item found");
            }
            else
            {
                await _publishEndpointHandler.PublishCatalogItemDeletedAsync(data);

                return Results.Ok();
            }
        }
    }
}
