using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMovementType;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovementType
{
    public class TicketMovementTypeViewModel
    {
        public SelectList? TicketStatusIds { get; set; }
        public TicketMovementTypeFilterModel FilterModel { get; set; } = new TicketMovementTypeFilterModel();
    }

    public class TicketMovementTypeFilterModel
    {
        public string? Name { get; set; }
        public int TicketStatusId { get; set; }
        public bool Accessible { get; set; }
        public bool IsDeleted { get; set; }
    }
}