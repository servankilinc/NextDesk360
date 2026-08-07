using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockModule.StockSerial.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockSerial
{
    public class StockSerialUpdateViewModel
    {
        public StockSerialUpdateDto UpdateModel { get; set; } = new StockSerialUpdateDto();
        public SelectList? StockIds { get; set; }
        public SelectList? CompanyIds { get; set; }
        public SelectList? WarehouseIds { get; set; }
    }
}