using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockType
{
    public class StockTypeCreateViewModel
    {
        public StockTypeCreateDto CreateModel { get; set; } = new StockTypeCreateDto();
    }
}