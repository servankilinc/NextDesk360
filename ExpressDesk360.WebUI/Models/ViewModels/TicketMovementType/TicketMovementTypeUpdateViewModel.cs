using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovementType
{
    public class TicketMovementTypeUpdateViewModel
    {
        public TicketMovementTypeUpdateDto UpdateModel { get; set; } = new TicketMovementTypeUpdateDto();
        public SelectList? TicketStatusIds { get; set; }
    }
}