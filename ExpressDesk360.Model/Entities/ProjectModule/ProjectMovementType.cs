using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.ProjectModule;

public class ProjectMovementType : IEntity, IActivatableEntity, IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ProjectStatusId { get; set; }
    public bool Accessible { get; set; }
    public string Color { get; set; } = null!;
    public string? InformationText { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual ProjectStatus? ProjectStatus { get; set; }
    public virtual ICollection<ProjectMovement>? ProjectMovements { get; set; }
}