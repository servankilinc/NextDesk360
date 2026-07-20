using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Company.Commands
{
    public class CompanyCreateDto : IDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Fax { get; set; }
        public bool ManagerApproval { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class CompanyCreateDtoValidator : AbstractValidator<CompanyCreateDto>
    {
        public CompanyCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}