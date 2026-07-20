using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketType.Commands
{
    public class TicketTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class TicketTypeUpdateDtoValidator : AbstractValidator<TicketTypeUpdateDto>
    {
        public TicketTypeUpdateDtoValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}