using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskMovement.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskMovement
{
    public class _TaskMovementCreateViewModel
    {
        public TaskMovementCreateDto CreateModel { get; set; } = new TaskMovementCreateDto();
        public SelectList? TaskIds { get; set; }
        public SelectList? TaskMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
    }
}