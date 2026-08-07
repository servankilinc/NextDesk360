using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMovementFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovementFile
{
    public class TicketMovementFileUpdateViewModel
    {
        public TicketMovementFileUpdateDto UpdateModel { get; set; } = new TicketMovementFileUpdateDto();
        public SelectList? TicketMovementIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}