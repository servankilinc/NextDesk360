using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockSerial.Commands
{
    public class StockSerialCreateDto : IDto
    {
        public Guid StockId { get; set; }
        public string? SerialNumber { get; set; }
        public Guid? CompanyId { get; set; }
        public int? WarehouseId { get; set; }
    }

    public class StockSerialCreateDtoValidator : AbstractValidator<StockSerialCreateDto>
    {
        public StockSerialCreateDtoValidator()
        {
            RuleFor(v => v.StockId).NotEqual(Guid.Empty).WithMessage("StockId must be a valid guid value");
        }
    }
}