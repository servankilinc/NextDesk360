using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.BOM.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.BOM
{
    public class BOMCreateViewModel
    {
        public BOMCreateDto CreateModel { get; set; } = new BOMCreateDto();
        public SelectList? StockIds { get; set; }
    }
}