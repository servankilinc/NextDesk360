using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyProductStockSerialMap;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProductStockSerialMap
{
    public class CompanyProductStockSerialMapViewModel
    {
        public CompanyProductStockSerialMapFilterModel FilterModel { get; set; } = new CompanyProductStockSerialMapFilterModel();
    }

    public class CompanyProductStockSerialMapFilterModel
    {
    }
}