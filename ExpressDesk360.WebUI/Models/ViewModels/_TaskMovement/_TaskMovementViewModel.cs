using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._TaskMovement;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskMovement
{
    public class _TaskMovementViewModel
    {
        public SelectList? TaskIds { get; set; }
        public SelectList? TaskMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
        public _TaskMovementFilterModel FilterModel { get; set; } = new _TaskMovementFilterModel();
    }

    public class _TaskMovementFilterModel
    {
        public Guid TaskId { get; set; }
        public int TaskMovementTypeId { get; set; }
        public Guid UserId { get; set; }
}
}