using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectMovementType
{
    public class ProjectMovementTypeCreateViewModel
    {
        public ProjectMovementTypeCreateDto CreateModel { get; set; } = new ProjectMovementTypeCreateDto();
        public SelectList? ProjectStatusIds { get; set; }
    }
}