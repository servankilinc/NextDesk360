using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Stock.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Stock
{
    public class StockCreateViewModel
    {
        public StockCreateDto CreateModel { get; set; } = new StockCreateDto();
        public SelectList? StockGroupIds { get; set; }
        public SelectList? StockBrandIds { get; set; }
        public SelectList? UnitIds { get; set; }
        public SelectList? PurchaseCurrencyIds { get; set; }
        public SelectList? SalePriceCurrencyIds { get; set; }
    }
}