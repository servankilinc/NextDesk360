using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockSerial.Commands
{
    public class StockSerialUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string? SerialNumber { get; set; }
        public Guid? CompanyId { get; set; }
        public int? WarehouseId { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class StockSerialUpdateDtoValidator : AbstractValidator<StockSerialUpdateDto>
    {
        public StockSerialUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
        }
    }
}