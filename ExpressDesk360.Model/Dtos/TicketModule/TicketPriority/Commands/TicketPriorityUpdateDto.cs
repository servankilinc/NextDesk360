using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketPriority.Commands
{
    public class TicketPriorityUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Icon { get; set; }
        public int Value { get; set; }
    }

    public class TicketPriorityUpdateDtoValidator : AbstractValidator<TicketPriorityUpdateDto>
    {
        public TicketPriorityUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
            RuleFor(v => v.Value).GreaterThan(-1).WithMessage("Value must be greater than -1");
        }
    }
}