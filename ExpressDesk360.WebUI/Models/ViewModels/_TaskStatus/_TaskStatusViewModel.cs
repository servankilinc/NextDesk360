using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._TaskStatus;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskStatus
{
    public class _TaskStatusViewModel
    {
        public _TaskStatusFilterModel FilterModel { get; set; } = new _TaskStatusFilterModel();
    }

    public class _TaskStatusFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}