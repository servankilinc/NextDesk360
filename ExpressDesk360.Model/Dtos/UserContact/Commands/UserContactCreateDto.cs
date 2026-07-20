using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.UserContact.Commands
{
    public class UserContactCreateDto : IDto
    {
        public Guid UserId { get; set; }
        public int ContactTypeId { get; set; }
        public string Info { get; set; } = null!;
    }

    public class UserContactCreateDtoValidator : AbstractValidator<UserContactCreateDto>
    {
        public UserContactCreateDtoValidator()
        {
            RuleFor(v => v.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid guid value");
            RuleFor(v => v.ContactTypeId).GreaterThan(0).WithMessage("ContactTypeId must be greater than 0");
            RuleFor(v => v.Info).NotEmpty().WithMessage("Info cannot be empty");
            RuleFor(v => v.Info).MaximumLength(100).WithMessage("Info cannot exceed 100 characters");
        }
    }
}