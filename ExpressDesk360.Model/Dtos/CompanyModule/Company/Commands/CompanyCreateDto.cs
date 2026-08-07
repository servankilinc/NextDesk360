using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyModule.Company.Commands;

public class CompanyCreateDto : IDto
{
    public string Name { get; set; } = string.Empty;
    public bool ManagerApproval { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CompanyCreateDtoValidator : AbstractValidator<CompanyCreateDto>
{
    public CompanyCreateDtoValidator()
    {
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        RuleFor(v => v.ManagerApproval).NotNull().WithMessage("Manager approval is required");
    }
}