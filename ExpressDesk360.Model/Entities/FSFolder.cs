using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class FSFolder : IEntity, ISoftDeletableEntity
    {
        public Guid Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? ParentFolderId { get; set; }
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual User? Owner { get; set; }
        public virtual FSFolder? ParentFolder { get; set; }
        public virtual ICollection<FSFile>? FolderFSFiles { get; set; }
        public virtual ICollection<FSFolder>? ParentFolderFSFolders { get; set; }
    }
}