using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProductStockSerialMap
{
    public class CompanyProductStockSerialMapUpdateViewModel
    {
        public CompanyProductStockSerialMapUpdateDto UpdateModel { get; set; } = new CompanyProductStockSerialMapUpdateDto();
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? StockSerialIds { get; set; }
    }
}