using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovement.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectMovement
{
    public class ProjectMovementUpdateViewModel
    {
        public ProjectMovementUpdateDto UpdateModel { get; set; } = new ProjectMovementUpdateDto();
        public SelectList? ProjectIds { get; set; }
        public SelectList? ProjectMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}