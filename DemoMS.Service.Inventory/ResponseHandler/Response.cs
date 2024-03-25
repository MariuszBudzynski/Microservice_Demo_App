namespace DemoMS.Service.Inventory.ResponseHandler
{
    public class Response
    {
        public async Task<IResult> ReturnResultAsync(IGetAllDataUseCase<InventoryItem> getAllDataUseCase, Guid id)
        {
            var data = (await getAllDataUseCase.
           ExecuteAsync(x => x.Id == id)).Select(x => x.Mapp<InventoryItem,InventoryItemDTO>(z=> new(z.Id,z.Quantity,z.AcquiredDate)));
            return Results.Ok(data);
        }
    }
}
