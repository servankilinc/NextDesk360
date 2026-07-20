using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockBrand.Commands
{
    public class StockBrandCreateDto : IDto
    {
        public string Name { get; set; } = null!;
    }

    public class StockBrandCreateDtoValidator : AbstractValidator<StockBrandCreateDto>
    {
        public StockBrandCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}