using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockBrand.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockBrand
{
    public class StockBrandCreateViewModel
    {
        public StockBrandCreateDto CreateModel { get; set; } = new StockBrandCreateDto();
    }
}