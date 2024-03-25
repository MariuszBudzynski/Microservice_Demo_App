namespace DemoMS.Service.Inventory.ResponseHandler
{
    public class Response
    {
        public async Task<IResult> ReturnResultAsync(IGetAllDataUseCase<InventoryItem> getAllDataUseCase, Guid id, MappData mapper)
        {
            var data = (await getAllDataUseCase.ExecuteAsync(x => x.Id == id)).Select(x => x.InventoryItemToInventoryItemDTO());
            return Results.Ok(data);
        }
    }
}
