using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.TaskModule.TaskStatus.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskStatus
{
    public class _TaskStatusCreateViewModel
    {
        public TaskStatusCreateDto CreateModel { get; set; } = new TaskStatusCreateDto();
    }
}