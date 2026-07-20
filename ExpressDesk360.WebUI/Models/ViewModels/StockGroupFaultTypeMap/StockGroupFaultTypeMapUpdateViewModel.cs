using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockGroupFaultTypeMap
{
    public class StockGroupFaultTypeMapUpdateViewModel
    {
        public StockGroupFaultTypeMapUpdateDto UpdateModel { get; set; } = new StockGroupFaultTypeMapUpdateDto();
        public SelectList? FaultTypeIds { get; set; }
        public SelectList? StockGroupIds { get; set; }
    }
}