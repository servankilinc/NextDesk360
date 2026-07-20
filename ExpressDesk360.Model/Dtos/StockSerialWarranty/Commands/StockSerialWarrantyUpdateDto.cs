using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.StockSerialWarranty.Commands
{
    public class StockSerialWarrantyUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public int WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }

    public class StockSerialWarrantyUpdateDtoValidator : AbstractValidator<StockSerialWarrantyUpdateDto>
    {
        public StockSerialWarrantyUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.StockSerialId).NotEqual(Guid.Empty).WithMessage("StockSerialId must be a valid guid value");
            RuleFor(v => v.WarrantyTypeId).GreaterThan(0).WithMessage("WarrantyTypeId must be greater than 0");
        }
    }
}