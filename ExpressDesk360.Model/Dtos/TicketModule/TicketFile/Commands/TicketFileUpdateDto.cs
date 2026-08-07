using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketFile.Commands
{
    public class TicketFileUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid FileId { get; set; }
    }

    public class TicketFileUpdateDtoValidator : AbstractValidator<TicketFileUpdateDto>
    {
        public TicketFileUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketId).NotEqual(Guid.Empty).WithMessage("TicketId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}