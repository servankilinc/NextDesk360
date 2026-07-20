using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProjectFile.Queries
{
    public class ProjectFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid FileId { get; set; }
    }
}