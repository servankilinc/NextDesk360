using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.TaskModule;

public class _TaskStatus : IEntity, IImmutableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual ICollection<TaskMovementType>? TaskMovementTypes { get; set; }
}