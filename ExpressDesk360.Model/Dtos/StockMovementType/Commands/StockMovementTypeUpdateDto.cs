using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockMovementType.Commands
{
    public class StockMovementTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public char InOutCode { get; set; }
        public string? Description { get; set; }
    }

    public class StockMovementTypeUpdateDtoValidator : AbstractValidator<StockMovementTypeUpdateDto>
    {
        public StockMovementTypeUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}