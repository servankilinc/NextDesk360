using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Common.WarrantyType.Commands;

public class WarrantyTypeUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class WarrantyTypeUpdateDtoValidator : AbstractValidator<WarrantyTypeUpdateDto>
{
    public WarrantyTypeUpdateDtoValidator()
    {
        RuleFor(v => v.Id).NotNull();
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
    }
}