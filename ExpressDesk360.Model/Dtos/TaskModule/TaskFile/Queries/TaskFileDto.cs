using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TaskModule.TaskFile.Queries
{
    public class TaskFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid FileId { get; set; }
    }
}