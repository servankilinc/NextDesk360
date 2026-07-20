using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Warehouse.Commands
{
    public class WarehouseUpdateDto : IDto
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class WarehouseUpdateDtoValidator : AbstractValidator<WarehouseUpdateDto>
    {
        public WarehouseUpdateDtoValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(v => v.CompanyId).NotEqual(Guid.Empty).WithMessage("CompanyId must be a valid guid value");
        }
    }
}