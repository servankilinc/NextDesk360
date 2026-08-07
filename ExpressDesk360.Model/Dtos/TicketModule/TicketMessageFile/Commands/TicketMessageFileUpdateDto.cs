using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketMessageFile.Commands
{
    public class TicketMessageFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketMessageId { get; set; }
        public Guid FileId { get; set; }
    }

    public class TicketMessageFileUpdateDtoValidator : AbstractValidator<TicketMessageFileUpdateDto>
    {
        public TicketMessageFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketMessageId).NotEqual(Guid.Empty).WithMessage("TicketMessageId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}