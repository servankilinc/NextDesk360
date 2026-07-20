using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Ticket.Commands
{
    public class TicketUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketPriorityId { get; set; }
        public Guid RequesterId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? CompanyProductId { get; set; }
        public int Number { get; set; }
        public int LastTicketMovementTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string? TicketDescription { get; set; }
        public bool RemoteSupport { get; set; }
        public bool UnderWarranty { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class TicketUpdateDtoValidator : AbstractValidator<TicketUpdateDto>
    {
        public TicketUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketTypeId).NotNull();
            RuleFor(v => v.TicketPriorityId).NotNull();
            RuleFor(v => v.RequesterId).NotEqual(Guid.Empty).WithMessage("RequesterId must be a valid guid value");
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.Number).NotNull();
            RuleFor(v => v.LastTicketMovementTypeId).NotNull();
            RuleFor(v => v.Title).NotEmpty().WithMessage("Title cannot be empty");
        }
    }
}