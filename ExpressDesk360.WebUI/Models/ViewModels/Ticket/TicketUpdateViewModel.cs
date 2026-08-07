using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Ticket
{
    public class TicketUpdateViewModel
    {
        public TicketUpdateDto UpdateModel { get; set; } = new TicketUpdateDto();
        public SelectList? TicketTypeIds { get; set; }
        public SelectList? TicketPriorityIds { get; set; }
        public SelectList? RequesterIds { get; set; }
        public SelectList? CompanyIds { get; set; }
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? LastTicketMovementTypeIds { get; set; }
    }
}