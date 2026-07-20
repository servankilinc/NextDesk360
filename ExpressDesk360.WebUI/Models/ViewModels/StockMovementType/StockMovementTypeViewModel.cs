using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockMovementType;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovementType
{
    public class StockMovementTypeViewModel
    {
        public StockMovementTypeFilterModel FilterModel { get; set; } = new StockMovementTypeFilterModel();
    }

    public class StockMovementTypeFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}