using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockType;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockType
{
    public class StockTypeViewModel
    {
        public StockTypeFilterModel FilterModel { get; set; } = new StockTypeFilterModel();
    }

    public class StockTypeFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}