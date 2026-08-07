using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProjectModule.ProjectStaff.Queries
{
    public class ProjectStaffDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}