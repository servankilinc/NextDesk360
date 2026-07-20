using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyContact.Commands
{
    public class CompanyContactCreateDto : IDto
    {
        public Guid CompanyId { get; set; }
        public int ContactTypeId { get; set; }
        public string Info { get; set; } = null!;
    }

    public class CompanyContactCreateDtoValidator : AbstractValidator<CompanyContactCreateDto>
    {
        public CompanyContactCreateDtoValidator()
        {
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.ContactTypeId).NotNull();
            RuleFor(v => v.Info).NotEmpty().WithMessage("Info cannot be empty");
            RuleFor(v => v.Info).MaximumLength(100).WithMessage("Info cannot exceed 100 characters");
        }
    }
}