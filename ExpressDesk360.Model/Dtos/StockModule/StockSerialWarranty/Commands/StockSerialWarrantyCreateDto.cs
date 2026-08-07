using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockModule.StockSerialWarranty.Commands
{
    public class StockSerialWarrantyCreateDto : IDto
    {
        public Guid StockSerialId { get; set; }
        public int WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }

    public class StockSerialWarrantyCreateDtoValidator : AbstractValidator<StockSerialWarrantyCreateDto>
    {
        public StockSerialWarrantyCreateDtoValidator()
        {
            RuleFor(v => v.StockSerialId).NotEqual(Guid.Empty).WithMessage("StockSerialId must be a valid guid value");
            RuleFor(v => v.WarrantyTypeId).NotNull();
        }
    }
}