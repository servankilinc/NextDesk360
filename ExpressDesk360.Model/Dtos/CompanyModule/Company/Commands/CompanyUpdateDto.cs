using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyModule.Company.Commands;

public class CompanyUpdateDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool ManagerApproval { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CompanyUpdateDtoValidator : AbstractValidator<CompanyUpdateDto>
{
    public CompanyUpdateDtoValidator()
    {
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        RuleFor(v => v.ManagerApproval).NotNull().WithMessage("Manager approval is required");
    }
}