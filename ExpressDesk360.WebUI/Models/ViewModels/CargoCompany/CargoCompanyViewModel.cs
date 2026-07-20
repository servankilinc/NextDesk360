using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.CargoCompany;

namespace ExpressDesk360.WebUI.Models.ViewModels.CargoCompany
{
    public class CargoCompanyViewModel
    {
        public CargoCompanyFilterModel FilterModel { get; set; } = new CargoCompanyFilterModel();
    }

    public class CargoCompanyFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}