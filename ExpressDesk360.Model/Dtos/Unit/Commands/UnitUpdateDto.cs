using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Unit.Commands
{
    public class UnitUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
    }

    public class UnitUpdateDtoValidator : AbstractValidator<UnitUpdateDto>
    {
        public UnitUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(50).WithMessage("Name cannot exceed 50 characters");
            RuleFor(v => v.ShortName).NotEmpty().WithMessage("ShortName cannot be empty");
            RuleFor(v => v.ShortName).MaximumLength(20).WithMessage("ShortName cannot exceed 20 characters");
        }
    }
}