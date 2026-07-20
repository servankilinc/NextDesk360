using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroup;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroup
{
    public class StockGroupViewModel
    {
        public StockGroupFilterModel FilterModel { get; set; } = new StockGroupFilterModel();
    }

    public class StockGroupFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}