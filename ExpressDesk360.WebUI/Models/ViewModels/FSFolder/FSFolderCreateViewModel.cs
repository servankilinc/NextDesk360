using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Common.FSFolder.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.FSFolder
{
    public class FSFolderCreateViewModel
    {
        public FSFolderCreateDto CreateModel { get; set; } = new FSFolderCreateDto();
        public SelectList? OwnerIds { get; set; }
        public SelectList? ParentFolderIds { get; set; }
    }
}