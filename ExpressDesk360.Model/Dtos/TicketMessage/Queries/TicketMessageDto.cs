using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketMessage.Queries
{
    public class TicketMessageDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public bool IsSystem { get; set; }
        public Guid? SenderId { get; set; }
        public bool ExternalAccess { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}