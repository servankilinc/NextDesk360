using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketServicePrice
{
    public class TicketServicePriceUpdateViewModel
    {
        public TicketServicePriceUpdateDto UpdateModel { get; set; } = new TicketServicePriceUpdateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? CurrencyIds { get; set; }
    }
}