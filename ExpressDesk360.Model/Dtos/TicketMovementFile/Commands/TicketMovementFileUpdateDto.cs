using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketMovementFile.Commands
{
    public class TicketMovementFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketMovementId { get; set; }
        public Guid FileId { get; set; }
    }

    public class TicketMovementFileUpdateDtoValidator : AbstractValidator<TicketMovementFileUpdateDto>
    {
        public TicketMovementFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketMovementId).NotEqual(Guid.Empty).WithMessage("TicketMovementId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}