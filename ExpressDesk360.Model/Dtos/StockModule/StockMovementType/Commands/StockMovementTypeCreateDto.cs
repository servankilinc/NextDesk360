using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovementType.Commands
{
    public class StockMovementTypeCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public char InOutCode { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class StockMovementTypeCreateDtoValidator : AbstractValidator<StockMovementTypeCreateDto>
    {
        public StockMovementTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}