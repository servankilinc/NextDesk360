using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroupFaultTypeMap;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroupFaultTypeMap
{
    public class StockGroupFaultTypeMapViewModel
    {
        public StockGroupFaultTypeMapFilterModel FilterModel { get; set; } = new StockGroupFaultTypeMapFilterModel();
    }

    public class StockGroupFaultTypeMapFilterModel
    {
        public bool IsDeleted { get; set; }
    }
}