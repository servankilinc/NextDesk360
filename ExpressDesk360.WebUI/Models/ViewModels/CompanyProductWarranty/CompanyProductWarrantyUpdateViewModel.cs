using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProductWarranty
{
    public class CompanyProductWarrantyUpdateViewModel
    {
        public CompanyProductWarrantyUpdateDto UpdateModel { get; set; } = new CompanyProductWarrantyUpdateDto();
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? WarrantyTypeIds { get; set; }
    }
}