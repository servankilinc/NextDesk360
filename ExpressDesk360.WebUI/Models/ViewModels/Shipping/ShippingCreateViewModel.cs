using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Shipping.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Shipping
{
    public class ShippingCreateViewModel
    {
        public ShippingCreateDto CreateModel { get; set; } = new ShippingCreateDto();
        public SelectList? CargoCompanyIds { get; set; }
        public SelectList? ShippingTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
        public SelectList? PriceCurrencyIds { get; set; }
    }
}