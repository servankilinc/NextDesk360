using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos._TaskFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskFile
{
    public class _TaskFileCreateViewModel
    {
        public TaskFileCreateDto CreateModel { get; set; } = new TaskFileCreateDto();
        public SelectList? TaskIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}