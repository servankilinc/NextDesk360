using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketPriority.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketPriority
{
    public class TicketPriorityUpdateViewModel
    {
        public TicketPriorityUpdateDto UpdateModel { get; set; } = new TicketPriorityUpdateDto();
    }
}