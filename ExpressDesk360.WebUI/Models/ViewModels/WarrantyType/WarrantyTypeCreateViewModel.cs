using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.WarrantyType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.WarrantyType
{
    public class WarrantyTypeCreateViewModel
    {
        public WarrantyTypeCreateDto CreateModel { get; set; } = new WarrantyTypeCreateDto();
    }
}