using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.InvoiceModule.InvoiceType.Commands;

public class InvoiceTypeUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public char InOutCode { get; set; }
    public string? NumberStart { get; set; }
    public bool IsActive { get; set; } = true;
}

public class InvoiceTypeUpdateDtoValidator : AbstractValidator<InvoiceTypeUpdateDto>
{
    public InvoiceTypeUpdateDtoValidator()
    {
        RuleFor(v => v.Id).NotNull();
        RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(v => v.Name).MaximumLength(200).WithMessage("Name cannot exceed 200 characters");
        RuleFor(v => v.InOutCode).NotEmpty().WithMessage("InOutCode cannot be empty");
    }
}