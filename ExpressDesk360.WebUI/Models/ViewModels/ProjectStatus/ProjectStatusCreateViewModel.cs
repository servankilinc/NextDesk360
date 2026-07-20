using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectStatus.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectStatus
{
    public class ProjectStatusCreateViewModel
    {
        public ProjectStatusCreateDto CreateModel { get; set; } = new ProjectStatusCreateDto();
    }
}