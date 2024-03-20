namespace DemoMS.Service.Validators
{
    public class CreatedItemDtoValidator : AbstractValidator<CreatedItemDto>
    {
        public CreatedItemDtoValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p=>p.Price).GreaterThan(0).LessThan(1000).WithMessage("Value must be in rage from 0 to 1000");
        }
    }
}
