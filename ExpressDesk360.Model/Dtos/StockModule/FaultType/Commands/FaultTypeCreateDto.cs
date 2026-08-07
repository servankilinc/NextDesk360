using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.FaultType.Commands
{
    public class FaultTypeCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class FaultTypeCreateDtoValidator : AbstractValidator<FaultTypeCreateDto>
    {
        public FaultTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}