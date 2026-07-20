using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.FSFolder;

namespace ExpressDesk360.WebUI.Models.ViewModels.FSFolder
{
    public class FSFolderViewModel
    {
        public SelectList? OwnerIds { get; set; }
        public SelectList? ParentFolderIds { get; set; }
        public FSFolderFilterModel FilterModel { get; set; } = new FSFolderFilterModel();
    }

    public class FSFolderFilterModel
    {
        public Guid OwnerId { get; set; }
        public Guid ParentFolderId { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public bool IsDeleted { get; set; }
    }
}