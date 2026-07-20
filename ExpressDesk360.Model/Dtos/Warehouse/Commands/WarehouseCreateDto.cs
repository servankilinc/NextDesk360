using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Warehouse.Commands
{
    public class WarehouseCreateDto : IDto
    {
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class WarehouseCreateDtoValidator : AbstractValidator<WarehouseCreateDto>
    {
        public WarehouseCreateDtoValidator()
        {
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
        }
    }
}