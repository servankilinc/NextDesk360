using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskMovementType
{
    public class _TaskMovementTypeUpdateViewModel
    {
        public TaskMovementTypeUpdateDto UpdateModel { get; set; } = new TaskMovementTypeUpdateDto();
        public SelectList? TaskStatusIds { get; set; }
    }
}