using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectStatus;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectStatus
{
    public class ProjectStatusViewModel
    {
        public ProjectStatusFilterModel FilterModel { get; set; } = new ProjectStatusFilterModel();
    }

    public class ProjectStatusFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}