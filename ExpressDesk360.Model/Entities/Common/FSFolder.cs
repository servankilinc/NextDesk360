using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Model.Entities.Common;

public class FSFolder : IEntity
{
    public Guid Id { get; set; }
    public Guid? OwnerId { get; set; }
    public Guid? ParentFolderId { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime CreateDate { get; set; }

    public virtual User? Owner { get; set; }
    public virtual FSFolder? ParentFolder { get; set; }
    public virtual ICollection<FSFile>? FolderFSFiles { get; set; }
    public virtual ICollection<FSFolder>? ParentFolderFSFolders { get; set; }
}