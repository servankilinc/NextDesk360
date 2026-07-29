using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class TicketMovementFile : IEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TicketMovementId { get; set; }
        public Guid FileId { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion
        public virtual TicketMovement? TicketMovement { get; set; }
        public virtual FSFile? File { get; set; }
    }
}