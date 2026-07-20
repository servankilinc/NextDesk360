using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockTypeGroupMap;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockTypeGroupMap
{
    public class StockTypeGroupMapViewModel
    {
        public StockTypeGroupMapFilterModel FilterModel { get; set; } = new StockTypeGroupMapFilterModel();
    }

    public class StockTypeGroupMapFilterModel
    {
        public bool IsDeleted { get; set; }
    }
}