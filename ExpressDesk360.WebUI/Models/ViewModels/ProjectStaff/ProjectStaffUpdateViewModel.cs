using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectStaff.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectStaff
{
    public class ProjectStaffUpdateViewModel
    {
        public ProjectStaffUpdateDto UpdateModel { get; set; } = new ProjectStaffUpdateDto();
        public SelectList? ProjectIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}