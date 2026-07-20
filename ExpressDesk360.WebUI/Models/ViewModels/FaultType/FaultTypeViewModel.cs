using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.FaultType;

namespace ExpressDesk360.WebUI.Models.ViewModels.FaultType
{
    public class FaultTypeViewModel
    {
        public FaultTypeFilterModel FilterModel { get; set; } = new FaultTypeFilterModel();
    }

    public class FaultTypeFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}