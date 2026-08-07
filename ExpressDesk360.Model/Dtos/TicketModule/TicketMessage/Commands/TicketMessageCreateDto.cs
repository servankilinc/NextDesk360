using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketMessage.Commands
{
    public class TicketMessageCreateDto : IDto
    {
        public Guid TicketId { get; set; }
        public bool IsSystem { get; set; }
        public Guid? SenderId { get; set; }
        public bool ExternalAccess { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }
    }

    public class TicketMessageCreateDtoValidator : AbstractValidator<TicketMessageCreateDto>
    {
        public TicketMessageCreateDtoValidator()
        {
            RuleFor(v => v.TicketId).NotEqual(Guid.Empty).WithMessage("TicketId must be a valid guid value");
            RuleFor(v => v.Content).NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}