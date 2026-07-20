using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProductWarranty
{
    public class CompanyProductWarrantyCreateViewModel
    {
        public CompanyProductWarrantyCreateDto CreateModel { get; set; } = new CompanyProductWarrantyCreateDto();
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? WarrantyTypeIds { get; set; }
    }
}