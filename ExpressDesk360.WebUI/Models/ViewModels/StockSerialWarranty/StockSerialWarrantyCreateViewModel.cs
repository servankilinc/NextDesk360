using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockSerialWarranty.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockSerialWarranty
{
    public class StockSerialWarrantyCreateViewModel
    {
        public StockSerialWarrantyCreateDto CreateModel { get; set; } = new StockSerialWarrantyCreateDto();
        public SelectList? StockSerialIds { get; set; }
        public SelectList? WarrantyTypeIds { get; set; }
    }
}