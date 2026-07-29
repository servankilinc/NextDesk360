using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ContactType;

namespace ExpressDesk360.WebUI.Models.ViewModels.ContactType
{
    public class ContactTypeViewModel
    {
        public ContactTypeFilterModel FilterModel { get; set; } = new ContactTypeFilterModel();
    }

    public class ContactTypeFilterModel
    {
        public bool IsActive { get; set; }
        public string? Name { get; set; }
    }
}