using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.UserFile.Commands
{
    public class UserFileCreateDto : IDto
    {
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }
    }

    public class UserFileCreateDtoValidator : AbstractValidator<UserFileCreateDto>
    {
        public UserFileCreateDtoValidator()
        {
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
            RuleFor(v => v.FileId).NotEqual(Guid.Empty).WithMessage("FileId must be a valid guid value");
        }
    }
}