namespace DemoMS.Service.Inventory.ResponseHandler
{
    public class Response : IResponse
    {
        private readonly IGetDataByIDUseCase<InventoryItem> _getDataByIDUseCase;
        private readonly IAddDataUseCase<InventoryItem> _addDataUseCase;
        private readonly IUpdateDataUseCase<InventoryItem> _updateDataUseCase;
        private readonly IGetAllDataUseCase<InventoryItem> _getAllDataUseCase;

        public Response(
            IGetDataByIDUseCase<InventoryItem> getDataByIDUseCase,
            IAddDataUseCase<InventoryItem> addDataUseCase,
            IUpdateDataUseCase<InventoryItem> updateDataUseCase,
            IGetAllDataUseCase<InventoryItem> getAllDataUseCase)
        {
            _getDataByIDUseCase = getDataByIDUseCase;
            _addDataUseCase = addDataUseCase;
            _updateDataUseCase = updateDataUseCase;
            _getAllDataUseCase = getAllDataUseCase;
        }

        public async Task<IResult> ReturnResultAsync(Guid id)
        {
            var data = (await _getAllDataUseCase
                .ExecuteAsync(x => x.Id == id))
                .Select(x => x.Mapp<InventoryItem, InventoryItemDTO>(z => new(z.CatalogItemId, z.Quantity, z.AcquiredDate)));

            return Results.Ok(data);
        }

        public async Task<IResult> ReturnResultAsync(GrantItemsDTO grantItemsDTO)
        {
            var data = await _getDataByIDUseCase.ExecuteAsync(x=> x.UserId == grantItemsDTO.UserId);

            if (data == null)
            {
                var mappItem = grantItemsDTO.Mapp<GrantItemsDTO, InventoryItem>(x => new()
                {
                    Id = Guid.NewGuid(),
                    UserId = grantItemsDTO.UserId,
                    CatalogItemId = grantItemsDTO.CatalogitemId,
                    Quantity = grantItemsDTO.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                });

                await _addDataUseCase.ExecuteAsync(mappItem);

                return Results.Created();
            }
            else
            {
                data.UserId = grantItemsDTO.UserId;
                data.CatalogItemId = grantItemsDTO.CatalogitemId;
                data.Quantity = grantItemsDTO.Quantity; 
                data.AcquiredDate = DateTimeOffset.UtcNow;

                await _updateDataUseCase.ExecuteAsync(data, data.Id);

                return Results.Ok();
            }
        }
    }
}