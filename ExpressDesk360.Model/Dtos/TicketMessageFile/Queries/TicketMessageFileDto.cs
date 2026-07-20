using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketMessageFile.Queries
{
    public class TicketMessageFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketMessageId { get; set; }
        public Guid FileId { get; set; }
    }
}