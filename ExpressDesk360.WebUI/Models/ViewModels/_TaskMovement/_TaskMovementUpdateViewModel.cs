using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskMovement
{
    public class _TaskMovementUpdateViewModel
    {
        public TaskMovementUpdateDto UpdateModel { get; set; } = new TaskMovementUpdateDto();
        public SelectList? TaskIds { get; set; }
        public SelectList? TaskMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}