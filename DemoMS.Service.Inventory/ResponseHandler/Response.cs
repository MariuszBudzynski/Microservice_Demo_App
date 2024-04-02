namespace DemoMS.Service.Inventory.ResponseHandler
{
    public class Response
    {
        // To DO - extract interface after implementing
        public async Task<IResult> ReturnResultAsync(IGetAllDataUseCase<InventoryItem> getAllDataUseCase, Guid id)
        {
            var data = (await getAllDataUseCase.
           ExecuteAsync(x => x.Id == id)).Select(x => x.Mapp<InventoryItem,InventoryItemDTO>(z=> new(z.Id,z.Quantity,z.AcquiredDate)));
            return Results.Ok(data);
        }

        public async Task<IResult> ReturnResultAsync(GrantItemsDTO grantItemsDTO,
                        IGetDataByIDUseCase<InventoryItem> getDataByIDUseCase,
                        IAddDataUseCase<InventoryItem> addDataUseCase,
                        IUpdateDataUseCase<InventoryItem> updateDataUseCase)
        {
            var data = await getDataByIDUseCase.ExecuteAsync(grantItemsDTO.UserId);

            if (data == null)
            {
                var mappItem = grantItemsDTO.Mapp<GrantItemsDTO, InventoryItem>(x => new()
                {
                    UserId = grantItemsDTO.UserId,
                    CatalogItemId = grantItemsDTO.CatalogitemId,
                    Quantity = grantItemsDTO.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                });

                await addDataUseCase.ExecuteAsync(mappItem);

                return Results.Created();
            }
            else if (data != null)
            {
                var mappItem = grantItemsDTO.Mapp<GrantItemsDTO, InventoryItem>(x => new()
                {
                    UserId = grantItemsDTO.UserId,
                    CatalogItemId = grantItemsDTO.CatalogitemId,
                    Quantity = grantItemsDTO.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                });

                await updateDataUseCase.ExecuteAsync(mappItem, data.Id);

               return Results.Ok();

            }

            return Results.Ok();
        }

    }
}
