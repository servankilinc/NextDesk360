using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketMovementFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovementFile
{
    public class TicketMovementFileCreateViewModel
    {
        public TicketMovementFileCreateDto CreateModel { get; set; } = new TicketMovementFileCreateDto();
        public SelectList? TicketMovementIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}