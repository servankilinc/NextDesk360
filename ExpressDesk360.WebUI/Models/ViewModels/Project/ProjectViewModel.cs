using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Project;

namespace ExpressDesk360.WebUI.Models.ViewModels.Project
{
    public class ProjectViewModel
    {
        public ProjectFilterModel FilterModel { get; set; } = new ProjectFilterModel();
    }

    public class ProjectFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}