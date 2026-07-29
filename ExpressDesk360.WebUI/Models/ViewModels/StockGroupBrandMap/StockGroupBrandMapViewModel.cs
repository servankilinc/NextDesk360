using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroupBrandMap;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroupBrandMap
{
    public class StockGroupBrandMapViewModel
    {
        public StockGroupBrandMapFilterModel FilterModel { get; set; } = new StockGroupBrandMapFilterModel();
    }

    public class StockGroupBrandMapFilterModel
    {
    }
}