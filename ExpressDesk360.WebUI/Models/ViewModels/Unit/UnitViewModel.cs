using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Unit;

namespace ExpressDesk360.WebUI.Models.ViewModels.Unit
{
    public class UnitViewModel
    {
        public UnitFilterModel FilterModel { get; set; } = new UnitFilterModel();
    }

    public class UnitFilterModel
    {
        public bool IsActive { get; set; }
        public string? Name { get; set; }
    }
}