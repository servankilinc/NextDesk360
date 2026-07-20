using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketFile.Commands
{
    public class TicketFileCreateDto : IDto
    {
        public Guid TicketId { get; set; }
        public Guid FileId { get; set; }
    }

    public class TicketFileCreateDtoValidator : AbstractValidator<TicketFileCreateDto>
    {
        public TicketFileCreateDtoValidator()
        {
            RuleFor(v => v.TicketId).NotEqual(Guid.Empty).WithMessage("TicketId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}