using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class _Task : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public int? TaskPriorityId { get; set; }
        public Guid? ReferenceId { get; set; }
        public Guid? OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public int LastTaskMovementTypeId { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual _TaskPriority? TaskPriority { get; set; }
        public virtual User? Owner { get; set; }
        public virtual _TaskMovementType? LastTaskMovementType { get; set; }
        public virtual ICollection<_TaskFile>? TaskFiles { get; set; }
        public virtual ICollection<_TaskMovement>? TaskMovements { get; set; }
        public virtual ICollection<_TaskStaff>? TaskStaffs { get; set; }
    }
}