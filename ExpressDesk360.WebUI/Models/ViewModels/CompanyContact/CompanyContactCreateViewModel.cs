using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyContact.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyContact
{
    public class CompanyContactCreateViewModel
    {
        public CompanyContactCreateDto CreateModel { get; set; } = new CompanyContactCreateDto();
        public SelectList? CompanyIds { get; set; }
        public SelectList? ContactTypeIds { get; set; }
    }
}