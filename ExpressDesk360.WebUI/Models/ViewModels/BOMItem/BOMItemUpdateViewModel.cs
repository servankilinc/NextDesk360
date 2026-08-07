using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProductionModule.BOMItem.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.BOMItem
{
    public class BOMItemUpdateViewModel
    {
        public BOMItemUpdateDto UpdateModel { get; set; } = new BOMItemUpdateDto();
        public SelectList? BOMIds { get; set; }
        public SelectList? StockIds { get; set; }
    }
}