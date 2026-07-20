using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketMovement.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovement
{
    public class TicketMovementUpdateViewModel
    {
        public TicketMovementUpdateDto UpdateModel { get; set; } = new TicketMovementUpdateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? TicketMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
        public SelectList? ShippingIds { get; set; }
        public SelectList? FaultTypeIds { get; set; }
    }
}