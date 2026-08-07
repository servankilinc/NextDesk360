using ExpressDesk360.Core.Model;
using ExpressDesk360.Core.Utils.DeleteBehavior;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Model.Entities.TaskModule;

public class _Task : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public int? TaskPriorityId { get; set; }
    public Guid? ReferenceId { get; set; }
    public Guid? OwnerId { get; set; }
    public string Name { get; set; } = null!;
    public int LastTaskMovementTypeId { get; set; }
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

    public virtual TaskPriority? TaskPriority { get; set; }
    public virtual User? Owner { get; set; }
    public virtual TaskMovementType? LastTaskMovementType { get; set; }
    public virtual ICollection<TaskFile>? TaskFiles { get; set; }
    public virtual ICollection<TaskMovement>? TaskMovements { get; set; }
    public virtual ICollection<TaskStaff>? TaskStaffs { get; set; }
}