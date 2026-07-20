using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovementType
{
    public class StockMovementTypeCreateViewModel
    {
        public StockMovementTypeCreateDto CreateModel { get; set; } = new StockMovementTypeCreateDto();
    }
}