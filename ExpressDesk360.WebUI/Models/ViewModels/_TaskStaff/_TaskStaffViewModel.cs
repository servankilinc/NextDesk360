using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._TaskStaff;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskStaff
{
    public class _TaskStaffViewModel
    {
        public SelectList? TaskIds { get; set; }
        public _TaskStaffFilterModel FilterModel { get; set; } = new _TaskStaffFilterModel();
    }

    public class _TaskStaffFilterModel
    {
        public Guid TaskId { get; set; }
    }
}