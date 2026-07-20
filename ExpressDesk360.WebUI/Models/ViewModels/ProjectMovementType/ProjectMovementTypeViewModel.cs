using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectMovementType;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectMovementType
{
    public class ProjectMovementTypeViewModel
    {
        public SelectList? ProjectStatusIds { get; set; }
        public ProjectMovementTypeFilterModel FilterModel { get; set; } = new ProjectMovementTypeFilterModel();
    }

    public class ProjectMovementTypeFilterModel
    {
        public string? Name { get; set; }
        public int ProjectStatusId { get; set; }
        public bool Accessible { get; set; }
        public string? InformationText { get; set; }
        public bool IsDeleted { get; set; }
    }
}