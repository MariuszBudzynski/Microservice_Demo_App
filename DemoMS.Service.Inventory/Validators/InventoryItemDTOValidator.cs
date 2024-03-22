namespace DemoMS.Service.Inventory.Validators
{
    public class InventoryItemDTOValidator : AbstractValidator<InventoryItemDTO>
    {
        public InventoryItemDTOValidator()
        {
            RuleFor(p=>p.Quantity).GreaterThan(0).LessThan(100).WithMessage("Value must be in rage from 0 to 100");
        }
    }
}
