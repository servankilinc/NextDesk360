using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProjectMovement.Queries
{
    public class ProjectMovementDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public int ProjectMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}