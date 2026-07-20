using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.FSFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.FSFile
{
    public class FSFileViewModel
    {
        public SelectList? FolderIds { get; set; }
        public FSFileFilterModel FilterModel { get; set; } = new FSFileFilterModel();
    }

    public class FSFileFilterModel
    {
        public Guid FolderId { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public bool IsDeleted { get; set; }
    }
}