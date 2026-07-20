using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos._TaskMovement.Queries
{
    public class TaskMovementDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public int TaskMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}