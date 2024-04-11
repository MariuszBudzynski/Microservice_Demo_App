namespace DemoMS.Service.Inventory.Validators
{
    public class GrantItemsDTOValidator : AbstractValidator<GrantItemsDTO>
    {
        private readonly IGetDataByIDUseCase<CatalogItem> _getCatalogItemByIdUseCase;

        public GrantItemsDTOValidator(IGetDataByIDUseCase<CatalogItem> getCatalogItemByIdUseCase)
        {

            RuleFor(p => p.Quantity).GreaterThan(0).LessThan(100).WithMessage("Value must be in range from 0 to 100");
            RuleFor(p => p.CatalogitemId).MustAsync(ExistCatalogItemId).WithMessage("Invalid CatalogitemId.");

            _getCatalogItemByIdUseCase = getCatalogItemByIdUseCase;
        }

        private async Task<bool> ExistCatalogItemId(Guid catalogItemId, CancellationToken cancellationToken)
        {
            var catalogItem = await _getCatalogItemByIdUseCase.ExecuteAsync(catalogItemId);

            return catalogItem != null;
        }

    }
}
