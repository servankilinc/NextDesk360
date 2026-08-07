using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Model.Entities.TaskModule;

public class TaskStaff : IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public DateTime JoinedDate { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual _Task? Task { get; set; }
    public virtual User? User { get; set; }
}