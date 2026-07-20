using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ContactType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.ContactType
{
    public class ContactTypeUpdateViewModel
    {
        public ContactTypeUpdateDto UpdateModel { get; set; } = new ContactTypeUpdateDto();
    }
}