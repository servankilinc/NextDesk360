using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketPriority.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketPriority
{
    public class TicketPriorityCreateViewModel
    {
        public TicketPriorityCreateDto CreateModel { get; set; } = new TicketPriorityCreateDto();
    }
}