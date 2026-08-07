using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ShippingModule.ShippingType.Commands
{
    public class ShippingTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class ShippingTypeUpdateDtoValidator : AbstractValidator<ShippingTypeUpdateDto>
    {
        public ShippingTypeUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}