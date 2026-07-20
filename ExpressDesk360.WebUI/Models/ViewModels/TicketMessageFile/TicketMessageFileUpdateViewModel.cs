using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketMessageFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMessageFile
{
    public class TicketMessageFileUpdateViewModel
    {
        public TicketMessageFileUpdateDto UpdateModel { get; set; } = new TicketMessageFileUpdateDto();
        public SelectList? TicketMessageIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}