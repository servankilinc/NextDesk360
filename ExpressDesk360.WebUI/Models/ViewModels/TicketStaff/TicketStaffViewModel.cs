using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketStaff;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketStaff
{
    public class TicketStaffViewModel
    {
        public SelectList? TicketIds { get; set; }
        public TicketStaffFilterModel FilterModel { get; set; } = new TicketStaffFilterModel();
    }

    public class TicketStaffFilterModel
    {
        public Guid TicketId { get; set; }
        public bool IsDeleted { get; set; }
    }
}