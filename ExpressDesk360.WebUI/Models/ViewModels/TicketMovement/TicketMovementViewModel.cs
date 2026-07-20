using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMovement;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovement
{
    public class TicketMovementViewModel
    {
        public SelectList? TicketIds { get; set; }
        public TicketMovementFilterModel FilterModel { get; set; } = new TicketMovementFilterModel();
    }

    public class TicketMovementFilterModel
    {
        public Guid TicketId { get; set; }
        public bool IsDeleted { get; set; }
    }
}