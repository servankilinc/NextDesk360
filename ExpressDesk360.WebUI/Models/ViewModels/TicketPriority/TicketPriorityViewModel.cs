using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketPriority;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketPriority
{
    public class TicketPriorityViewModel
    {
        public TicketPriorityFilterModel FilterModel { get; set; } = new TicketPriorityFilterModel();
    }

    public class TicketPriorityFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}