using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._Task;

namespace ExpressDesk360.WebUI.Models.ViewModels._Task
{
    public class _TaskViewModel
    {
        public SelectList? TaskPriorityIds { get; set; }
        public SelectList? LastTaskMovementTypeIds { get; set; }
        public _TaskFilterModel FilterModel { get; set; } = new _TaskFilterModel();
    }

    public class _TaskFilterModel
    {
        public int TaskPriorityId { get; set; }
        public string? Name { get; set; }
        public int LastTaskMovementTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}