using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class _TaskMovement : IEntity, IImmutableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public int TaskMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion

public virtual _Task? Task { get; set; }
        public virtual _TaskMovementType? TaskMovementType { get; set; }
        public virtual User? User { get; set; }
    }
}