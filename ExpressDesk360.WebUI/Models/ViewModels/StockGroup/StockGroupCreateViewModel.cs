using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockGroup.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroup
{
    public class StockGroupCreateViewModel
    {
        public StockGroupCreateDto CreateModel { get; set; } = new StockGroupCreateDto();
    }
}