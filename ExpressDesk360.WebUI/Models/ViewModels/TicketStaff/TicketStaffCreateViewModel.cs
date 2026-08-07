using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStaff.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketStaff
{
    public class TicketStaffCreateViewModel
    {
        public TicketStaffCreateDto CreateModel { get; set; } = new TicketStaffCreateDto();
        public SelectList? TicketIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}