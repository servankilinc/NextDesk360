using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class TicketStaff : IEntity, ISoftDeletableEntity
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AddedDate { get; set; }
        
        #region ISoftDeletableEntity
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; } 
        #endregion
        
        public virtual Ticket? Ticket { get; set; }
        public virtual User? User { get; set; }
    }
}