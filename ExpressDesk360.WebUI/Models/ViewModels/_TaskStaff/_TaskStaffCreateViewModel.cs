using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskStaff.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskStaff
{
    public class _TaskStaffCreateViewModel
    {
        public TaskStaffCreateDto CreateModel { get; set; } = new TaskStaffCreateDto();
        public SelectList? TaskIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}