using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class TicketMessage : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public bool IsSystem { get; set; }
        public Guid? SenderId { get; set; }
        public bool ExternalAccess { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual User? Sender { get; set; }
        public virtual ICollection<TicketMessageFile>? TicketMessageFiles { get; set; }
    }
}