using DemoMS.Service.Catalog.ResponseHandler.Interfaces;
using DemoMS.Service.Common.Extensions;

namespace DemoMS.Service.Catalog.ResponseHandler
{
    public class Response : IResponse
    {
        public async Task<IResult> ReturnResultAsync(IGetAllDataUseCase<Item> getAllDataUseCase)
        {
            var items = (await getAllDataUseCase.ExecuteAsync()).Select(x => x.Mapp<Item, ItemDto>(x => new(x.Id, x.Name, x.Description, x.Price, x.CreatedDate)));
            return Results.Ok(items);
        }

        public async Task<IResult> ReturnResultAsync(Guid id, IGetDataByIDUseCase<Item> getDataByIDUseCase)
        {
            var data = (await getDataByIDUseCase.ExecuteAsync(id)).Mapp<Item, ItemDto>(x => new(x.Id, x.Name, x.Description, x.Price, x.CreatedDate));
            if (data != null)
            {
                return Results.Ok(data);
            }
            else return Results.NotFound("No data found");
        }

        public async Task<IResult> ReturnResultAsync(CreatedItemDto item, IAddDataUseCase<Item> addDataUseCase)
        {
            await addDataUseCase.ExecuteAsync(item.Mapp<CreatedItemDto, Item>(x => new()
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = DateTimeOffset.Now
            }));
            return Results.Created();
        }

        public async Task<IResult> ReturnResultAsync(Guid id, UpdateItemDTO item,
                                   IUpdateDataUseCase<Item> updateDataUseCase)
        {
            var data = await updateDataUseCase.ExecuteAsync(item.Mapp<UpdateItemDTO, Item>(x => new()
            {
                Id = id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = DateTimeOffset.Now
            }), id);

            return data == null ? Results.NotFound("No item found") : Results.NoContent();
        }
        public async Task<IResult> ReturnResultAsync(Guid id, IDeleteDataUseCase<Item> deleteDataUseCase)
        {
            var data = await deleteDataUseCase.ExecuteAsync(id);
            return data == null ? Results.NotFound("No item found") : Results.Ok();
        }
    }
}
