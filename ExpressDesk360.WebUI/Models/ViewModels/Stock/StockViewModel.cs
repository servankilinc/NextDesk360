using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Stock;

namespace ExpressDesk360.WebUI.Models.ViewModels.Stock
{
    public class StockViewModel
    {
        public SelectList? StockGroupIds { get; set; }
        public SelectList? StockBrandIds { get; set; }
        public StockFilterModel FilterModel { get; set; } = new StockFilterModel();
    }

    public class StockFilterModel
    {
        public bool IsActive { get; set; }
        public int StockGroupId { get; set; }
        public int StockBrandId { get; set; }
        public bool SerialTracking { get; set; }
        public bool VirtualSeries { get; set; }
    }
}