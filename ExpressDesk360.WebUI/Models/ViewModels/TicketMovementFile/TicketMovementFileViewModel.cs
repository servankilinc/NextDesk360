using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMovementFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMovementFile
{
    public class TicketMovementFileViewModel
    {
        public SelectList? TicketMovementIds { get; set; }
        public TicketMovementFileFilterModel FilterModel { get; set; } = new TicketMovementFileFilterModel();
    }

    public class TicketMovementFileFilterModel
    {
        public Guid TicketMovementId { get; set; }
        public bool IsDeleted { get; set; }
    }
}