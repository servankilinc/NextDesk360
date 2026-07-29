using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectStaff;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectStaff
{
    public class ProjectStaffViewModel
    {
        public SelectList? ProjectIds { get; set; }
        public SelectList? UserIds { get; set; }
        public ProjectStaffFilterModel FilterModel { get; set; } = new ProjectStaffFilterModel();
    }

    public class ProjectStaffFilterModel
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}