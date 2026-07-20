using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CompanyProduct.Commands
{
    public class CompanyProductCreateDto : IDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public Guid? StockId { get; set; }
        public Guid? BOMId { get; set; }
    }

    public class CompanyProductCreateDtoValidator : AbstractValidator<CompanyProductCreateDto>
    {
        public CompanyProductCreateDtoValidator()
        {
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(1000).WithMessage("Name cannot exceed 1000 characters");
        }
    }
}