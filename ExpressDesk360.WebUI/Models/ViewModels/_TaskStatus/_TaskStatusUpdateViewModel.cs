using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskStatus.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskStatus
{
    public class _TaskStatusUpdateViewModel
    {
        public TaskStatusUpdateDto UpdateModel { get; set; } = new TaskStatusUpdateDto();
    }
}