using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovementType
{
    public class StockMovementTypeUpdateViewModel
    {
        public StockMovementTypeUpdateDto UpdateModel { get; set; } = new StockMovementTypeUpdateDto();
    }
}