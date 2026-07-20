using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroupBrandMap
{
    public class StockGroupBrandMapUpdateViewModel
    {
        public StockGroupBrandMapUpdateDto UpdateModel { get; set; } = new StockGroupBrandMapUpdateDto();
        public SelectList? StockBrandIds { get; set; }
        public SelectList? StockGroupIds { get; set; }
    }
}