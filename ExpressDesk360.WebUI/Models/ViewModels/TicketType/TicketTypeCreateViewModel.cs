using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TicketModule.TicketType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.TicketType
{
    public class TicketTypeCreateViewModel
    {
        public TicketTypeCreateDto CreateModel { get; set; } = new TicketTypeCreateDto();
    }
}