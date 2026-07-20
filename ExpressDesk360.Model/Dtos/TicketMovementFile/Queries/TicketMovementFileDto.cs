using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketMovementFile.Queries
{
    public class TicketMovementFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketMovementId { get; set; }
        public Guid FileId { get; set; }
    }
}