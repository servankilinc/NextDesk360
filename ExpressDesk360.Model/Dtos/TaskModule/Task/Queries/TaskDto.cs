using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TaskModule.Task.Queries
{
    public class TaskDto : IDto
    {
        public Guid Id { get; set; }
        public int? TaskPriorityId { get; set; }
        public Guid? ReferenceId { get; set; }
        public Guid? OwnerId { get; set; }
        public string Name { get; set; } = null!;
        public int LastTaskMovementTypeId { get; set; }
        public string? Description { get; set; }
    }
}