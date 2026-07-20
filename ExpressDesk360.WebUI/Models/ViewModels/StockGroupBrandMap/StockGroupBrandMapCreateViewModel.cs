using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroupBrandMap
{
    public class StockGroupBrandMapCreateViewModel
    {
        public StockGroupBrandMapCreateDto CreateModel { get; set; } = new StockGroupBrandMapCreateDto();
        public SelectList? StockBrandIds { get; set; }
        public SelectList? StockGroupIds { get; set; }
    }
}