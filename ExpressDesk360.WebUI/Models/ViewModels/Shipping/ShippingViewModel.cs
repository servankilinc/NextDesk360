using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Shipping;

namespace ExpressDesk360.WebUI.Models.ViewModels.Shipping
{
    public class ShippingViewModel
    {
        public SelectList? CargoCompanyIds { get; set; }
        public SelectList? ShippingTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
        public ShippingFilterModel FilterModel { get; set; } = new ShippingFilterModel();
    }

    public class ShippingFilterModel
    {
        public int CargoCompanyId { get; set; }
        public int ShippingTypeId { get; set; }
        public Guid UserId { get; set; }
        public string? SendingCompanyName { get; set; }
        public string? ReceivingCompanyName { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}