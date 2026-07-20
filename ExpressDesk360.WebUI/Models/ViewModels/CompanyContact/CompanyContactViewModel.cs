using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyContact;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyContact
{
    public class CompanyContactViewModel
    {
        public SelectList? CompanyIds { get; set; }
        public SelectList? ContactTypeIds { get; set; }
        public CompanyContactFilterModel FilterModel { get; set; } = new CompanyContactFilterModel();
    }

    public class CompanyContactFilterModel
    {
        public Guid CompanyId { get; set; }
        public int ContactTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}