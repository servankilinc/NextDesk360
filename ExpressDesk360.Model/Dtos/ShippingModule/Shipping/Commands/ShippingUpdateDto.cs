using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.ShippingModule.Shipping.Commands
{
    public class ShippingUpdateDto : IDto
    {
        public Guid Id { get; set; }
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

    public class ShippingUpdateDtoValidator : AbstractValidator<ShippingUpdateDto>
    {
        public ShippingUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.CargoCompanyId).NotNull();
            RuleFor(v => v.ShippingTypeId).NotNull();
        }
    }
}