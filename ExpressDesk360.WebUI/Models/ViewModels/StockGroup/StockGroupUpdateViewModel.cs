using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockGroup.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroup
{
    public class StockGroupUpdateViewModel
    {
        public StockGroupUpdateDto UpdateModel { get; set; } = new StockGroupUpdateDto();
    }
}