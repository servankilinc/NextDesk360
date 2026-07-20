using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketStatus.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketStatus
{
    public class TicketStatusUpdateViewModel
    {
        public TicketStatusUpdateDto UpdateModel { get; set; } = new TicketStatusUpdateDto();
    }
}