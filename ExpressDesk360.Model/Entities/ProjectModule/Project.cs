using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.ProjectModule;

public class Project : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? Deadline { get; set; }
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

    public virtual ICollection<ProjectFile>? ProjectFiles { get; set; }
    public virtual ICollection<ProjectMovement>? ProjectMovements { get; set; }
    public virtual ICollection<ProjectStaff>? ProjectStaffs { get; set; }
}