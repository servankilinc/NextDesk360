using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.UserContact;

namespace ExpressDesk360.WebUI.Models.ViewModels.UserContact
{
    public class UserContactViewModel
    {
        public SelectList? UserIds { get; set; }
        public SelectList? ContactTypeIds { get; set; }
        public UserContactFilterModel FilterModel { get; set; } = new UserContactFilterModel();
    }

    public class UserContactFilterModel
    {
        public Guid UserId { get; set; }
        public int ContactTypeId { get; set; }
    }
}