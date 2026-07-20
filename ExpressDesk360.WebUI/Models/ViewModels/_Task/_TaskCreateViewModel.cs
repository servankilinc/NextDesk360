using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._Task.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._Task
{
    public class _TaskCreateViewModel
    {
        public TaskCreateDto CreateModel { get; set; } = new TaskCreateDto();
        public SelectList? TaskPriorityIds { get; set; }
        public SelectList? OwnerIds { get; set; }
        public SelectList? LastTaskMovementTypeIds { get; set; }
    }
}