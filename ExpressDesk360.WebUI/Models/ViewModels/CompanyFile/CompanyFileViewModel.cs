using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyFile
{
    public class CompanyFileViewModel
    {
        public SelectList? CompanyIds { get; set; }
        public SelectList? FileIds { get; set; }
        public CompanyFileFilterModel FilterModel { get; set; } = new CompanyFileFilterModel();
    }

    public class CompanyFileFilterModel
    {
        public Guid CompanyId { get; set; }
        public Guid FileId { get; set; }
    }
}