using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._TaskMovementType;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskMovementType
{
    public class _TaskMovementTypeViewModel
    {
        public SelectList? TaskStatusIds { get; set; }
        public _TaskMovementTypeFilterModel FilterModel { get; set; } = new _TaskMovementTypeFilterModel();
    }

    public class _TaskMovementTypeFilterModel
    {
        public string? Name { get; set; }
        public int TaskStatusId { get; set; }
        public bool Accessible { get; set; }
        public bool IsDeleted { get; set; }
    }
}