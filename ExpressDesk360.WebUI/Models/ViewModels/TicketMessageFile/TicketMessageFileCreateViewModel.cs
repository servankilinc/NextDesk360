using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMessageFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMessageFile
{
    public class TicketMessageFileCreateViewModel
    {
        public TicketMessageFileCreateDto CreateModel { get; set; } = new TicketMessageFileCreateDto();
        public SelectList? TicketMessageIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}