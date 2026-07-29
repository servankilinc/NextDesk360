using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Currency.Commands
{
    public class CurrencyUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }

    public class CurrencyUpdateDtoValidator : AbstractValidator<CurrencyUpdateDto>
    {
        public CurrencyUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(50).WithMessage("Name cannot exceed 50 characters");
            RuleFor(v => v.ShortName).NotEmpty().WithMessage("ShortName cannot be empty");
            RuleFor(v => v.ShortName).MaximumLength(20).WithMessage("ShortName cannot exceed 20 characters");
            RuleFor(v => v.Icon).NotEmpty().WithMessage("Icon cannot be empty");
            RuleFor(v => v.Icon).MaximumLength(500).WithMessage("Icon cannot exceed 500 characters");
        }
    }
}