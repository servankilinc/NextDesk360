using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketFile
{
    public class TicketFileCreateViewModel
    {
        public TicketFileCreateDto CreateModel { get; set; } = new TicketFileCreateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}