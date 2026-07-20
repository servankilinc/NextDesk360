using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.InvoiceType.Commands
{
    public class InvoiceTypeCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public char InOutCode { get; set; }
        public string? NumberStart { get; set; }
        public byte Status { get; set; }
    }

    public class InvoiceTypeCreateDtoValidator : AbstractValidator<InvoiceTypeCreateDto>
    {
        public InvoiceTypeCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(200).WithMessage("Name cannot exceed 200 characters");
        }
    }
}