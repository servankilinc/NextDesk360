using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketType.Queries
{
    public class TicketTypeDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}