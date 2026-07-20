using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketFile
{
    public class TicketFileUpdateViewModel
    {
        public TicketFileUpdateDto UpdateModel { get; set; } = new TicketFileUpdateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}