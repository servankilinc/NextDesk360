using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyProductWarranty;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProductWarranty
{
    public class CompanyProductWarrantyViewModel
    {
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? WarrantyTypeIds { get; set; }
        public CompanyProductWarrantyFilterModel FilterModel { get; set; } = new CompanyProductWarrantyFilterModel();
    }

    public class CompanyProductWarrantyFilterModel
    {
        public Guid CompanyProductId { get; set; }
        public int WarrantyTypeId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}