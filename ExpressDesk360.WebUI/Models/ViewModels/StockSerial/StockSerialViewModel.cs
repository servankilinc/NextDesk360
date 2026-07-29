using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockSerial;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockSerial
{
    public class StockSerialViewModel
    {
        public SelectList? StockIds { get; set; }
        public SelectList? CompanyIds { get; set; }
        public SelectList? WarehouseIds { get; set; }
        public StockSerialFilterModel FilterModel { get; set; } = new StockSerialFilterModel();
    }

    public class StockSerialFilterModel
    {
        public bool IsActive { get; set; }
        public Guid StockId { get; set; }
        public string? SerialNumber { get; set; }
        public Guid CompanyId { get; set; }
        public int WarehouseId { get; set; }
    }
}