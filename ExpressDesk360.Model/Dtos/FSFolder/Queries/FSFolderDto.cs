using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.FSFolder.Queries
{
    public class FSFolderDto : IDto
    {
        public Guid Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? ParentFolderId { get; set; }
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}