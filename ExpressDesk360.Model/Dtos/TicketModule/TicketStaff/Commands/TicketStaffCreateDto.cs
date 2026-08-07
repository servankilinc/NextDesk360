using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketStaff.Commands
{
    public class TicketStaffCreateDto : IDto
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AddedDate { get; set; }
    }

    public class TicketStaffCreateDtoValidator : AbstractValidator<TicketStaffCreateDto>
    {
        public TicketStaffCreateDtoValidator()
        {
            RuleFor(v => v.TicketId).NotEqual(Guid.Empty).WithMessage("TicketId must be a valid guid value");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}