using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyProduct;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProduct
{
    public class CompanyProductViewModel
    {
        public SelectList? CompanyIds { get; set; }
        public SelectList? StockIds { get; set; }
        public CompanyProductFilterModel FilterModel { get; set; } = new CompanyProductFilterModel();
    }

    public class CompanyProductFilterModel
    {
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public Guid StockId { get; set; }
        public bool IsDeleted { get; set; }
    }
}