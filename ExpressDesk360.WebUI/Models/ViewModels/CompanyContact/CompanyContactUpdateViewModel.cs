using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyContact.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyContact
{
    public class CompanyContactUpdateViewModel
    {
        public CompanyContactUpdateDto UpdateModel { get; set; } = new CompanyContactUpdateDto();
        public SelectList? CompanyIds { get; set; }
        public SelectList? ContactTypeIds { get; set; }
    }
}