using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.Shipping.Queries
{
    public class ShippingDto : IDto
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
}