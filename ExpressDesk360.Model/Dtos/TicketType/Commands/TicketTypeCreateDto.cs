using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketType.Commands
{
    public class TicketTypeCreateDto : IDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}