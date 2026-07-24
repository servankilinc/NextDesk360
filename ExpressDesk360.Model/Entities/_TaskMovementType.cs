using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class _TaskMovementType : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TaskStatusId { get; set; }
        public bool Accessible { get; set; }
        public string Color { get; set; } = null!;
        public string? InformationText { get; set; }
        public string? Description { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion

        #region ISoftDeletableEntity
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        #endregion

        public virtual _TaskStatus? TaskStatus { get; set; }
        public virtual ICollection<_Task>? LastTaskMovementTypeTasks { get; set; }
        public virtual ICollection<_TaskMovement>? TaskMovements { get; set; }
    }
}