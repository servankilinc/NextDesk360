using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class TicketStaff : IEntity
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual User? User { get; set; }
    }
}