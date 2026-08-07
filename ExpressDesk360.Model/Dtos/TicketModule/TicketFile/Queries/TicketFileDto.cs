using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketFile.Queries
{
    public class TicketFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid FileId { get; set; }
    }
}