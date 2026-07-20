using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.CargoCompany.Commands
{
    public class CargoCompanyCreateDto : IDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class CargoCompanyCreateDtoValidator : AbstractValidator<CargoCompanyCreateDto>
    {
        public CargoCompanyCreateDtoValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}