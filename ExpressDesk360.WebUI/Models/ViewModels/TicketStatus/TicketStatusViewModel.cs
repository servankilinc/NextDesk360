using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketStatus;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketStatus
{
    public class TicketStatusViewModel
    {
        public TicketStatusFilterModel FilterModel { get; set; } = new TicketStatusFilterModel();
    }

    public class TicketStatusFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}