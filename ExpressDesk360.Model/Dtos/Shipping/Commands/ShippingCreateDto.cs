using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Shipping.Commands
{
    public class ShippingCreateDto : IDto
    {
        public int CargoCompanyId { get; set; }
        public int ShippingTypeId { get; set; }
        public Guid? UserId { get; set; }
        public string? SendingCompanyName { get; set; }
        public string? ReceivingCompanyName { get; set; }
        public bool IsIncoming { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal? Price { get; set; }
        public int? PriceCurrencyId { get; set; }
    }

    public class ShippingCreateDtoValidator : AbstractValidator<ShippingCreateDto>
    {
        public ShippingCreateDtoValidator()
        {
            RuleFor(v => v.CargoCompanyId).GreaterThan(0).WithMessage("CargoCompanyId must be greater than 0");
            RuleFor(v => v.ShippingTypeId).GreaterThan(0).WithMessage("ShippingTypeId must be greater than 0");
        }
    }
}