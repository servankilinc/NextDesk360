using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.User.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.User
{
    public class UserUpdateViewModel
    {
        public UserUpdateDto UpdateModel { get; set; } = new UserUpdateDto();
        public SelectList? CompanyIds { get; set; }
    }
}