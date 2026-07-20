using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.UserFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.UserFile
{
    public class UserFileViewModel
    {
        public SelectList? UserIds { get; set; }
        public SelectList? FileIds { get; set; }
        public UserFileFilterModel FilterModel { get; set; } = new UserFileFilterModel();
    }

    public class UserFileFilterModel
    {
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }
        public bool IsDeleted { get; set; }
    }
}