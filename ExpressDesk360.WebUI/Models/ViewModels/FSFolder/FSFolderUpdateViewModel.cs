using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.FSFolder.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.FSFolder
{
    public class FSFolderUpdateViewModel
    {
        public FSFolderUpdateDto UpdateModel { get; set; } = new FSFolderUpdateDto();
        public SelectList? OwnerIds { get; set; }
        public SelectList? ParentFolderIds { get; set; }
    }
}