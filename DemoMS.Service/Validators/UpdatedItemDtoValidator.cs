using DemoMS.Service.DTOS;
using FluentValidation;

namespace DemoMS.Service.Validators
{
    public class UpdatedItemDtoValidator : AbstractValidator<UpdateItemDTO>
    {
        public UpdatedItemDtoValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p=>p.Price).GreaterThan(0).LessThan(1000).WithMessage("Value must be in rage from 0 to 1000");
        }
    }
}
