using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketType;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketType
{
    public class TicketTypeViewModel
    {
        public TicketTypeFilterModel FilterModel { get; set; } = new TicketTypeFilterModel();
    }

    public class TicketTypeFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}