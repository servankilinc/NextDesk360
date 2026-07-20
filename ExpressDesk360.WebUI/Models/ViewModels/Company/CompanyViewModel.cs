using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Company;

namespace ExpressDesk360.WebUI.Models.ViewModels.Company
{
    public class CompanyViewModel
    {
        public CompanyFilterModel FilterModel { get; set; } = new CompanyFilterModel();
    }

    public class CompanyFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}