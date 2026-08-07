using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStaff.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketStaff
{
    public class TicketStaffUpdateViewModel
    {
        public TicketStaffUpdateDto UpdateModel { get; set; } = new TicketStaffUpdateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}