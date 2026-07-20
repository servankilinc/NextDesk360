using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.User.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.User
{
    public class UserCreateViewModel
    {
        public UserCreateDto CreateModel { get; set; } = new UserCreateDto();
        public SelectList? CompanyIds { get; set; }
    }
}