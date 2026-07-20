using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ContactType.Commands
{
    public class ContactTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }

    public class ContactTypeUpdateDtoValidator : AbstractValidator<ContactTypeUpdateDto>
    {
        public ContactTypeUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotNull();
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
            RuleFor(v => v.Icon).NotEmpty().WithMessage("Icon cannot be empty");
            RuleFor(v => v.Icon).MaximumLength(1000).WithMessage("Icon cannot exceed 1000 characters");
        }
    }
}