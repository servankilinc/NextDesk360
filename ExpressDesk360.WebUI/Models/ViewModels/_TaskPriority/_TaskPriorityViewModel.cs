using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._TaskPriority;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskPriority
{
    public class _TaskPriorityViewModel
    {
        public _TaskPriorityFilterModel FilterModel { get; set; } = new _TaskPriorityFilterModel();
    }

    public class _TaskPriorityFilterModel
    {
        public string? Name { get; set; }
}
}