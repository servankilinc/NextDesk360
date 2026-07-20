using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockSerialWarranty.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockSerialWarranty
{
    public class StockSerialWarrantyUpdateViewModel
    {
        public StockSerialWarrantyUpdateDto UpdateModel { get; set; } = new StockSerialWarrantyUpdateDto();
        public SelectList? StockSerialIds { get; set; }
        public SelectList? WarrantyTypeIds { get; set; }
    }
}