using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.UserFile.Queries
{
    public class UserFileDto : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }
    }
}