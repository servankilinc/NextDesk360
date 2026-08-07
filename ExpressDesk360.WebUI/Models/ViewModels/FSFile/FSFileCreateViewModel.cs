using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Common.FSFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.FSFile
{
    public class FSFileCreateViewModel
    {
        public FSFileCreateDto CreateModel { get; set; } = new FSFileCreateDto();
        public SelectList? FolderIds { get; set; }
    }
}