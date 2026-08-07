using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStatus.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketStatus
{
    public class TicketStatusCreateViewModel
    {
        public TicketStatusCreateDto CreateModel { get; set; } = new TicketStatusCreateDto();
    }
}