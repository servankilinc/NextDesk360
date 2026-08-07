using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketType.Commands
{
    public class TicketTypeCreateDto : IDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class TicketTypeCreateDtoValidator : AbstractValidator<TicketTypeCreateDto>
    {
        public TicketTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}