using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketMovementType.Commands
{
    public class TicketMovementTypeCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public int TicketStatusId { get; set; }
        public bool Accessible { get; set; }
        public string Color { get; set; } = null!;
        public string? InformationText { get; set; }
        public string? Description { get; set; }
    }

    public class TicketMovementTypeCreateDtoValidator : AbstractValidator<TicketMovementTypeCreateDto>
    {
        public TicketMovementTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
            RuleFor(v => v.TicketStatusId).GreaterThan(0).WithMessage("TicketStatusId must be greater than 0");
            RuleFor(v => v.Color).NotEmpty().WithMessage("Color cannot be empty");
            RuleFor(v => v.Color).MaximumLength(500).WithMessage("Color cannot exceed 500 characters");
        }
    }
}