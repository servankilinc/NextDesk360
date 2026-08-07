using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities.TaskModule;

public class TaskPriority : IEntity, IActivatableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Color { get; set; }
    public string? Icon { get; set; }
    public int Value { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<_Task>? Tasks { get; set; }
}