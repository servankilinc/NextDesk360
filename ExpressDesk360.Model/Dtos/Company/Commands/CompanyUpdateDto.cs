using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Company.Commands
{
    public class CompanyUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Fax { get; set; }
        public bool ManagerApproval { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class CompanyUpdateDtoValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
        }
    }
}