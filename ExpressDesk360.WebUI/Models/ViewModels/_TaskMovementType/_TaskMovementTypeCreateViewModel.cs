using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskMovementType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskMovementType
{
    public class _TaskMovementTypeCreateViewModel
    {
        public TaskMovementTypeCreateDto CreateModel { get; set; } = new TaskMovementTypeCreateDto();
        public SelectList? TaskStatusIds { get; set; }
    }
}