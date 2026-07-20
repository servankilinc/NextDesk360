using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectMovement.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectMovement
{
    public class ProjectMovementCreateViewModel
    {
        public ProjectMovementCreateDto CreateModel { get; set; } = new ProjectMovementCreateDto();
        public SelectList? ProjectIds { get; set; }
        public SelectList? ProjectMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}