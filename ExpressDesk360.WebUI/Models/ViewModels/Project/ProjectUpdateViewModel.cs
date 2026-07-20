using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Project.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Project
{
    public class ProjectUpdateViewModel
    {
        public ProjectUpdateDto UpdateModel { get; set; } = new ProjectUpdateDto();
    }
}