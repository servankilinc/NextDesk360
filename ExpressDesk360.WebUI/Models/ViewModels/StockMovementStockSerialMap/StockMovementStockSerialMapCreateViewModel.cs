using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockMovementStockSerialMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovementStockSerialMap
{
    public class StockMovementStockSerialMapCreateViewModel
    {
        public StockMovementStockSerialMapCreateDto CreateModel { get; set; } = new StockMovementStockSerialMapCreateDto();
        public SelectList? StockSerialIds { get; set; }
        public SelectList? StockMovementIds { get; set; }
    }
}