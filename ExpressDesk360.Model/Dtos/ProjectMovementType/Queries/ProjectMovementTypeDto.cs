using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProjectMovementType.Queries
{
    public class ProjectMovementTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProjectStatusId { get; set; }
        public bool Accessible { get; set; }
        public string Color { get; set; } = null!;
        public string? InformationText { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}