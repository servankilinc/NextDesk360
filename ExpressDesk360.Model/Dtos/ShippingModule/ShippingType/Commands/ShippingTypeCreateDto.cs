using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ShippingModule.ShippingType.Commands
{
    public class ShippingTypeCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class ShippingTypeCreateDtoValidator : AbstractValidator<ShippingTypeCreateDto>
    {
        public ShippingTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}