using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ShippingModule.ShippingFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ShippingFile
{
    public class ShippingFileCreateViewModel
    {
        public ShippingFileCreateDto CreateModel { get; set; } = new ShippingFileCreateDto();
        public SelectList? ShippingIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}