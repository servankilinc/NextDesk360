using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class TicketMovement : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public int TicketMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ShippingId { get; set; }
        public int? FaultTypeId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual TicketMovementType? TicketMovementType { get; set; }
        public virtual User? User { get; set; }
        public virtual Shipping? Shipping { get; set; }
        public virtual FaultType? FaultType { get; set; }
        public virtual ICollection<StockMovement>? StockMovements { get; set; }
        public virtual ICollection<TicketMovementFile>? TicketMovementFiles { get; set; }
    }
}