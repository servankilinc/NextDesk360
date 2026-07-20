using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockBrand.Commands
{
    public class StockBrandUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class StockBrandUpdateDtoValidator : AbstractValidator<StockBrandUpdateDto>
    {
        public StockBrandUpdateDtoValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(v => v.Name).MaximumLength(500).WithMessage("Name cannot exceed 500 characters");
        }
    }
}