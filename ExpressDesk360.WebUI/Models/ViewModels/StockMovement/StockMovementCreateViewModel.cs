using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockModule.StockMovement.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovement
{
    public class StockMovementCreateViewModel
    {
        public StockMovementCreateDto CreateModel { get; set; } = new StockMovementCreateDto();
        public SelectList? StockIds { get; set; }
        public SelectList? StockMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
        public SelectList? InvoiceIds { get; set; }
        public SelectList? TicketMovementIds { get; set; }
        public SelectList? WarehouseIds { get; set; }
    }
}