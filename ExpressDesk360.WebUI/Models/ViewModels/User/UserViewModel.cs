using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.User;

namespace ExpressDesk360.WebUI.Models.ViewModels.User
{
    public class UserViewModel
    {
        public SelectList? CompanyIds { get; set; }
        public UserFilterModel FilterModel { get; set; } = new UserFilterModel();
    }

    public class UserFilterModel
    {
        public Guid CompanyId { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public bool IsDeleted { get; set; }
    }
}