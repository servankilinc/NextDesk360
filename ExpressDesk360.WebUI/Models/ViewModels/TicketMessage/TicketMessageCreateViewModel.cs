using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMessage.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMessage
{
    public class TicketMessageCreateViewModel
    {
        public TicketMessageCreateDto CreateModel { get; set; } = new TicketMessageCreateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? SenderIds { get; set; }
    }
}