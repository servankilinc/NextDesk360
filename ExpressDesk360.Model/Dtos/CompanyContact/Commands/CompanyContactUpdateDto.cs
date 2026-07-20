using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyContact.Commands
{
    public class CompanyContactUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int ContactTypeId { get; set; }
        public string Info { get; set; } = null!;
    }

    public class CompanyContactUpdateDtoValidator : AbstractValidator<CompanyContactUpdateDto>
    {
        public CompanyContactUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.ContactTypeId).NotNull();
            RuleFor(v => v.Info).NotEmpty().WithMessage("Info cannot be empty");
            RuleFor(v => v.Info).MaximumLength(100).WithMessage("Info cannot exceed 100 characters");
        }
    }
}