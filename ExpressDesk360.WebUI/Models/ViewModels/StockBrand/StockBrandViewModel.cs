using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockBrand;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockBrand
{
    public class StockBrandViewModel
    {
        public StockBrandFilterModel FilterModel { get; set; } = new StockBrandFilterModel();
    }

    public class StockBrandFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}