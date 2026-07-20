using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProjectStaff.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectStaff
{
    public class ProjectStaffCreateViewModel
    {
        public ProjectStaffCreateDto CreateModel { get; set; } = new ProjectStaffCreateDto();
        public SelectList? ProjectIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}