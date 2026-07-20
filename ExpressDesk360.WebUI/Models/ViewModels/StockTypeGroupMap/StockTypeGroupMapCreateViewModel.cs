using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockTypeGroupMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockTypeGroupMap
{
    public class StockTypeGroupMapCreateViewModel
    {
        public StockTypeGroupMapCreateDto CreateModel { get; set; } = new StockTypeGroupMapCreateDto();
        public SelectList? StockTypeIds { get; set; }
        public SelectList? StockGroupIds { get; set; }
    }
}