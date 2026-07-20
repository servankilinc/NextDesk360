using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.TicketServicePrice;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketServicePrice
{
    public class TicketServicePriceViewModel
    {
        public SelectList? TicketIds { get; set; }
        public TicketServicePriceFilterModel FilterModel { get; set; } = new TicketServicePriceFilterModel();
    }

    public class TicketServicePriceFilterModel
    {
        public Guid TicketId { get; set; }
        public bool IsDeleted { get; set; }
    }
}