using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProjectModule.Project.Queries
{
    public class ProjectDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Description { get; set; }
    }
}