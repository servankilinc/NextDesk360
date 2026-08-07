using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.UserModule.UserFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.UserFile
{
    public class UserFileUpdateViewModel
    {
        public UserFileUpdateDto UpdateModel { get; set; } = new UserFileUpdateDto();
        public SelectList? UserIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}