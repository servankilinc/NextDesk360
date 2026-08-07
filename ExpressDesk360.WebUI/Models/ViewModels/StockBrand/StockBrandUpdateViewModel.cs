using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockModule.StockBrand.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockBrand
{
    public class StockBrandUpdateViewModel
    {
        public StockBrandUpdateDto UpdateModel { get; set; } = new StockBrandUpdateDto();
    }
}