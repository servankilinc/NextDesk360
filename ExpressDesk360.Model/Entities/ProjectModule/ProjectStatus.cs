using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.ProjectModule;

public class ProjectStatus : IEntity, IImmutableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual ICollection<ProjectMovementType>? ProjectMovementTypes { get; set; }
}