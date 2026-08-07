using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProductionModule.BOM.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.BOM
{
    public class BOMUpdateViewModel
    {
        public BOMUpdateDto UpdateModel { get; set; } = new BOMUpdateDto();
        public SelectList? StockIds { get; set; }
    }
}