using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectMovementType
{
    public class ProjectMovementTypeUpdateViewModel
    {
        public ProjectMovementTypeUpdateDto UpdateModel { get; set; } = new ProjectMovementTypeUpdateDto();
        public SelectList? ProjectStatusIds { get; set; }
    }
}