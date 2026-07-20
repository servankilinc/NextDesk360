using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ShippingType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ShippingType
{
    public class ShippingTypeUpdateViewModel
    {
        public ShippingTypeUpdateDto UpdateModel { get; set; } = new ShippingTypeUpdateDto();
    }
}