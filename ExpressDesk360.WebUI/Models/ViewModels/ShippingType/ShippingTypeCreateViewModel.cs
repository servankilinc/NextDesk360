using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ShippingType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ShippingType
{
    public class ShippingTypeCreateViewModel
    {
        public ShippingTypeCreateDto CreateModel { get; set; } = new ShippingTypeCreateDto();
    }
}