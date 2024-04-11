namespace DemoMS.Service.Inventory.ResponseHandler
{
    public class ReturnResponse : IReturnResponse
    {
        private readonly IGetDataByIDUseCase<InventoryItem> _getInventoryItemByIDUseCase;
        private readonly IAddDataUseCase<InventoryItem> _addDataUseCase;
        private readonly IUpdateDataUseCase<InventoryItem> _updateDataUseCase;
        private readonly InventoryItemDTOHelper _inventoryItemDTOHelper;
        private readonly IGetDataByIDUseCase<CatalogItem> _getCatalogItemByIdUseCase;

        public ReturnResponse(
            IGetDataByIDUseCase<InventoryItem> getInventoryItemByIDUseCase,
            IAddDataUseCase<InventoryItem> addDataUseCase,
            IUpdateDataUseCase<InventoryItem> updateDataUseCase,
            InventoryItemDTOHelper inventoryItemDTOHelper,
            IGetDataByIDUseCase<CatalogItem> getCatalogItemByIdUseCase
            )
        {
            _getInventoryItemByIDUseCase = getInventoryItemByIDUseCase;
            _addDataUseCase = addDataUseCase;
            _updateDataUseCase = updateDataUseCase;
            _inventoryItemDTOHelper = inventoryItemDTOHelper;
            _getCatalogItemByIdUseCase = getCatalogItemByIdUseCase;
        }

        public async Task<IResult> ReturnResultAsync(Guid id)
        {
            var inventoryItem = await _getInventoryItemByIDUseCase.ExecuteAsync(id);

           
            if (inventoryItem != null)
            {
                var catalogItem = await _getCatalogItemByIdUseCase.ExecuteAsync(inventoryItem.CatalogItemId);

                return Results.Ok(await _inventoryItemDTOHelper.CreateInventoryItemDTOAsync(catalogItem, inventoryItem));
            }

            return Results.NotFound($"Item id {id} not found");

        }

        public async Task<IResult> ReturnResultAsync(GrantItemsDTO grantItemsDTO)
        {
            var data = await _getInventoryItemByIDUseCase.ExecuteAsync(x=> x.UserId == grantItemsDTO.UserId);

            var catalogItem = await _getCatalogItemByIdUseCase.ExecuteAsync(grantItemsDTO.CatalogitemId);


            if (data == null)
            {
                var mappItem = grantItemsDTO.Mapp<GrantItemsDTO, InventoryItem>(x => new()
                {
                    Id = Guid.NewGuid(),
                    UserId = grantItemsDTO.UserId,
                    CatalogItemId = catalogItem.Id,
                    Quantity = grantItemsDTO.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                });

                await _addDataUseCase.ExecuteAsync(mappItem);

                return Results.Created();
            }
            else
            {
                data.UserId = grantItemsDTO.UserId;
                data.CatalogItemId = catalogItem.Id;
                data.Quantity = grantItemsDTO.Quantity;
                data.AcquiredDate = DateTimeOffset.UtcNow;

                await _updateDataUseCase.ExecuteAsync(data, data.Id);

                return Results.Ok();
            }
        }
    }
}