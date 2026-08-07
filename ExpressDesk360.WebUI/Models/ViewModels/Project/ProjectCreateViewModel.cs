using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectModule.Project.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Project
{
    public class ProjectCreateViewModel
    {
        public ProjectCreateDto CreateModel { get; set; } = new ProjectCreateDto();
    }
}