using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskFile
{
    public class _TaskFileUpdateViewModel
    {
        public TaskFileUpdateDto UpdateModel { get; set; } = new TaskFileUpdateDto();
        public SelectList? TaskIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}