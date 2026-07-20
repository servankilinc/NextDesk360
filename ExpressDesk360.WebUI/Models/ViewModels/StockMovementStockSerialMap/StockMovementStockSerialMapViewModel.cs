using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockMovementStockSerialMap;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovementStockSerialMap
{
    public class StockMovementStockSerialMapViewModel
    {
        public StockMovementStockSerialMapFilterModel FilterModel { get; set; } = new StockMovementStockSerialMapFilterModel();
    }

    public class StockMovementStockSerialMapFilterModel
    {
        public bool IsDeleted { get; set; }
    }
}