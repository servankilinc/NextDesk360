using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketType
{
    public class TicketTypeUpdateViewModel
    {
        public TicketTypeUpdateDto UpdateModel { get; set; } = new TicketTypeUpdateDto();
    }
}