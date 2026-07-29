using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockGroup.Commands
{
    public class StockGroupCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }

    public class StockGroupCreateDtoValidator : AbstractValidator<StockGroupCreateDto>
    {
        public StockGroupCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}