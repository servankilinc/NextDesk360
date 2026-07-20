using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketFile
{
    public class TicketFileViewModel
    {
        public SelectList? TicketIds { get; set; }
        public TicketFileFilterModel FilterModel { get; set; } = new TicketFileFilterModel();
    }

    public class TicketFileFilterModel
    {
        public Guid TicketId { get; set; }
        public bool IsDeleted { get; set; }
    }
}