using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.UserContact.Commands
{
    public class UserContactUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ContactTypeId { get; set; }
        public string Info { get; set; } = null!;
    }

    public class UserContactUpdateDtoValidator : AbstractValidator<UserContactUpdateDto>
    {
        public UserContactUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
            RuleFor(v => v.ContactTypeId).NotNull();
            RuleFor(v => v.Info).NotEmpty().WithMessage("Info cannot be empty");
            RuleFor(v => v.Info).MaximumLength(100).WithMessage("Info cannot exceed 100 characters");
        }
    }
}