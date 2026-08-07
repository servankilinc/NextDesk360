using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TaskModule.TaskPriority.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskPriority
{
    public class _TaskPriorityUpdateViewModel
    {
        public TaskPriorityUpdateDto UpdateModel { get; set; } = new TaskPriorityUpdateDto();
    }
}