using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectFile
{
    public class ProjectFileCreateViewModel
    {
        public ProjectFileCreateDto CreateModel { get; set; } = new ProjectFileCreateDto();
        public SelectList? ProjectIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}