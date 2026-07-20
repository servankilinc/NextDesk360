using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectStatus.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectStatus
{
    public class ProjectStatusUpdateViewModel
    {
        public ProjectStatusUpdateDto UpdateModel { get; set; } = new ProjectStatusUpdateDto();
    }
}