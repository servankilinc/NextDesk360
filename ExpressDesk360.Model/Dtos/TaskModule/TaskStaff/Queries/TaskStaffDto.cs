using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskStaff.Queries
{
    public class TaskStaffDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}