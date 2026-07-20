using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMessageFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMessageFile
{
    public class TicketMessageFileViewModel
    {
        public SelectList? TicketMessageIds { get; set; }
        public TicketMessageFileFilterModel FilterModel { get; set; } = new TicketMessageFileFilterModel();
    }

    public class TicketMessageFileFilterModel
    {
        public Guid TicketMessageId { get; set; }
        public bool IsDeleted { get; set; }
    }
}