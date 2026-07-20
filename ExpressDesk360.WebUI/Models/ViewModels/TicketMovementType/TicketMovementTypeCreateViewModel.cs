using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovementType
{
    public class TicketMovementTypeCreateViewModel
    {
        public TicketMovementTypeCreateDto CreateModel { get; set; } = new TicketMovementTypeCreateDto();
        public SelectList? TicketStatusIds { get; set; }
    }
}