using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Ticket.Commands
{
    public class TicketCreateDto : IDto
    {
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

    public class TicketCreateDtoValidator : AbstractValidator<TicketCreateDto>
    {
        public TicketCreateDtoValidator()
        {
            RuleFor(v => v.TicketTypeId).GreaterThan(0).WithMessage("TicketTypeId must be greater than 0");
            RuleFor(v => v.TicketPriorityId).GreaterThan(0).WithMessage("TicketPriorityId must be greater than 0");
            RuleFor(v => v.RequesterId).NotEqual(Guid.Empty).WithMessage("RequesterId must be a valid guid value");
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.Number).GreaterThan(0).WithMessage("Number must be greater than 0");
            RuleFor(v => v.LastTicketMovementTypeId).GreaterThan(0).WithMessage("LastTicketMovementTypeId must be greater than 0");
            RuleFor(v => v.Title).NotEmpty().WithMessage("Title cannot be empty");
        }
    }
}