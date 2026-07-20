using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.WarrantyType;

namespace ExpressDesk360.WebUI.Models.ViewModels.WarrantyType
{
    public class WarrantyTypeViewModel
    {
        public WarrantyTypeFilterModel FilterModel { get; set; } = new WarrantyTypeFilterModel();
    }

    public class WarrantyTypeFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}