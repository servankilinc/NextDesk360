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
        public bool IsActive { get; set; }
        public string? Name { get; set; }
    }
}