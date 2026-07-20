using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.FSFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.FSFile
{
    public class FSFileUpdateViewModel
    {
        public FSFileUpdateDto UpdateModel { get; set; } = new FSFileUpdateDto();
        public SelectList? FolderIds { get; set; }
    }
}