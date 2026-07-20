using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.UserFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.UserFile
{
    public class UserFileCreateViewModel
    {
        public UserFileCreateDto CreateModel { get; set; } = new UserFileCreateDto();
        public SelectList? UserIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}