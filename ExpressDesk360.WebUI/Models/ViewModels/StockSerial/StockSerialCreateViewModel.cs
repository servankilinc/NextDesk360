using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockModule.StockSerial.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockSerial
{
    public class StockSerialCreateViewModel
    {
        public StockSerialCreateDto CreateModel { get; set; } = new StockSerialCreateDto();
        public SelectList? StockIds { get; set; }
        public SelectList? CompanyIds { get; set; }
        public SelectList? WarehouseIds { get; set; }
    }
}