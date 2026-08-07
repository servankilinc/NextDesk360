using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.UserModule.UserContact.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.UserContact
{
    public class UserContactUpdateViewModel
    {
        public UserContactUpdateDto UpdateModel { get; set; } = new UserContactUpdateDto();
        public SelectList? UserIds { get; set; }
        public SelectList? ContactTypeIds { get; set; }
    }
}