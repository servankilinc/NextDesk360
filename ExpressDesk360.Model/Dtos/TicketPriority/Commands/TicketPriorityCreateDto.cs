using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketPriority.Commands
{
    public class TicketPriorityCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Icon { get; set; }
        public int Value { get; set; }
    }

    public class TicketPriorityCreateDtoValidator : AbstractValidator<TicketPriorityCreateDto>
    {
        public TicketPriorityCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
            RuleFor(v => v.Value).GreaterThan(0).WithMessage("Value must be greater than 0");
        }
    }
}