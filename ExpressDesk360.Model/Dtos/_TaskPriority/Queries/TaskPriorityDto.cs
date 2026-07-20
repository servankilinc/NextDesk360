using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos._TaskPriority.Queries
{
    public class TaskPriorityDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Icon { get; set; }
        public int Value { get; set; }
    }
}