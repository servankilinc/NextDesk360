using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.Ticket.Commands
{
    public class TicketUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketPriorityId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? CompanyProductId { get; set; }
        public string Title { get; set; } = null!;
        public string? TicketDescription { get; set; }
    }

    public class TicketUpdateDtoValidator : AbstractValidator<TicketUpdateDto>
    {
        public TicketUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketTypeId).NotNull();
            RuleFor(v => v.TicketPriorityId).NotNull();
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.Title).NotEmpty().WithMessage("Title cannot be empty");
        }
    }
}