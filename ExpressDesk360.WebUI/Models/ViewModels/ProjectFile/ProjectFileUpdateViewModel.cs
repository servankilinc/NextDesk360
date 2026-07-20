using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectFile
{
    public class ProjectFileUpdateViewModel
    {
        public ProjectFileUpdateDto UpdateModel { get; set; } = new ProjectFileUpdateDto();
        public SelectList? ProjectIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}