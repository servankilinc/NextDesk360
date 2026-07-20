using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Ticket;

namespace ExpressDesk360.WebUI.Models.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public SelectList? TicketTypeIds { get; set; }
        public SelectList? TicketPriorityIds { get; set; }
        public SelectList? CompanyIds { get; set; }
        public SelectList? CompanyProductIds { get; set; }
        public SelectList? LastTicketMovementTypeIds { get; set; }
        public TicketFilterModel FilterModel { get; set; } = new TicketFilterModel();
    }

    public class TicketFilterModel
    {
        public int TicketTypeId { get; set; }
        public int TicketPriorityId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CompanyProductId { get; set; }
        public int LastTicketMovementTypeId { get; set; }
        public bool RemoteSupport { get; set; }
        public DateTime? Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}