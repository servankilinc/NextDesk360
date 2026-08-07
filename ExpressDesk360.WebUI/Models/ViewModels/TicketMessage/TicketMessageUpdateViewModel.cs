using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMessage.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMessage
{
    public class TicketMessageUpdateViewModel
    {
        public TicketMessageUpdateDto UpdateModel { get; set; } = new TicketMessageUpdateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? SenderIds { get; set; }
    }
}