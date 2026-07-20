using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMessage;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketMessage
{
    public class TicketMessageViewModel
    {
        public SelectList? TicketIds { get; set; }
        public SelectList? SenderIds { get; set; }
        public TicketMessageFilterModel FilterModel { get; set; } = new TicketMessageFilterModel();
    }

    public class TicketMessageFilterModel
    {
        public Guid TicketId { get; set; }
        public bool IsSystem { get; set; }
        public Guid SenderId { get; set; }
        public bool IsDeleted { get; set; }
    }
}