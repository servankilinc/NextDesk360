using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockTypeGroupMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockTypeGroupMap
{
    public class StockTypeGroupMapUpdateViewModel
    {
        public StockTypeGroupMapUpdateDto UpdateModel { get; set; } = new StockTypeGroupMapUpdateDto();
        public SelectList? StockTypeIds { get; set; }
        public SelectList? StockGroupIds { get; set; }
    }
}