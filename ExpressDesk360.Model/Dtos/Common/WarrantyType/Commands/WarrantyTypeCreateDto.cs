using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Common.WarrantyType.Commands;

public class WarrantyTypeCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class WarrantyTypeCreateDtoValidator : AbstractValidator<WarrantyTypeCreateDto>
{
    public WarrantyTypeCreateDtoValidator()
    {
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
    }
}