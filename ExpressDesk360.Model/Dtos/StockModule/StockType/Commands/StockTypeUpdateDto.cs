using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockType.Commands
{
    public class StockTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class StockTypeUpdateDtoValidator : AbstractValidator<StockTypeUpdateDto>
    {
        public StockTypeUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}