using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyProductStockSerialMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProductStockSerialMap
{
    public class CompanyProductStockSerialMapCreateViewModel
    {
        public CompanyProductStockSerialMapCreateDto CreateModel { get; set; } = new CompanyProductStockSerialMapCreateDto();
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? StockSerialIds { get; set; }
    }
}