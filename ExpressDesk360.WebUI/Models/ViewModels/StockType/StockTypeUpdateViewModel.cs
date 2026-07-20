using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockType
{
    public class StockTypeUpdateViewModel
    {
        public StockTypeUpdateDto UpdateModel { get; set; } = new StockTypeUpdateDto();
    }
}