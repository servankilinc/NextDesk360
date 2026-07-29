using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectMovement;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectMovement
{
    public class ProjectMovementViewModel
    {
        public SelectList? ProjectIds { get; set; }
        public ProjectMovementFilterModel FilterModel { get; set; } = new ProjectMovementFilterModel();
    }

    public class ProjectMovementFilterModel
    {
        public Guid ProjectId { get; set; }
}
}