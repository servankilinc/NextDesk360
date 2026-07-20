using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.BOMItem.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.BOMItem
{
    public class BOMItemCreateViewModel
    {
        public BOMItemCreateDto CreateModel { get; set; } = new BOMItemCreateDto();
        public SelectList? BOMIds { get; set; }
        public SelectList? StockIds { get; set; }
    }
}