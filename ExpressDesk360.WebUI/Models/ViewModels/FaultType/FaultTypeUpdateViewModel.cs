using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockModule.FaultType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.FaultType
{
    public class FaultTypeUpdateViewModel
    {
        public FaultTypeUpdateDto UpdateModel { get; set; } = new FaultTypeUpdateDto();
    }
}