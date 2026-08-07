using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockModule.FaultType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.FaultType
{
    public class FaultTypeCreateViewModel
    {
        public FaultTypeCreateDto CreateModel { get; set; } = new FaultTypeCreateDto();
    }
}