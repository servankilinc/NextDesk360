using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketServicePrice
{
    public class TicketServicePriceCreateViewModel
    {
        public TicketServicePriceCreateDto CreateModel { get; set; } = new TicketServicePriceCreateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? CurrencyIds { get; set; }
    }
}