using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ShippingType;

namespace ExpressDesk360.WebUI.Models.ViewModels.ShippingType
{
    public class ShippingTypeViewModel
    {
        public ShippingTypeFilterModel FilterModel { get; set; } = new ShippingTypeFilterModel();
    }

    public class ShippingTypeFilterModel
    {
        public bool IsActive { get; set; }
        public string? Name { get; set; }
    }
}