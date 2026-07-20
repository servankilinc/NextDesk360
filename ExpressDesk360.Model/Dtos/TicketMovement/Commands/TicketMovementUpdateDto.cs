using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketMovement.Commands
{
    public class TicketMovementUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public int TicketMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ShippingId { get; set; }
        public int? FaultTypeId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }

    public class TicketMovementUpdateDtoValidator : AbstractValidator<TicketMovementUpdateDto>
    {
        public TicketMovementUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketId).NotEqual(Guid.Empty).WithMessage("TicketId must be a valid guid value");
            RuleFor(v => v.TicketMovementTypeId).GreaterThan(0).WithMessage("TicketMovementTypeId must be greater than 0");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
        }
    }
}