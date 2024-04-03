using FluentValidation;

namespace DemoMS.Service.Inventory.Validators
{
    public class GrantItemsDTOValidator : AbstractValidator<GrantItemsDTO>
    {
        private readonly ICatalogClient _catalogClient;
        public GrantItemsDTOValidator(ICatalogClient catalogClient)
        {
            _catalogClient = catalogClient;

            RuleFor(p => p.Quantity).GreaterThan(0).LessThan(100).WithMessage("Value must be in range from 0 to 100");
            RuleFor(p => p.CatalogitemId).MustAsync(ExistCatalogItemId).WithMessage("Invalid CatalogitemId.");

        }

        private async Task<bool> ExistCatalogItemId(Guid catalogItemId, CancellationToken cancellationToken)
        {
            var catalogItem = (await _catalogClient.GetCatalogItemsAsync()).FirstOrDefault(x=>x.Id == catalogItemId);

            return catalogItem != null;
        }

    }
}
