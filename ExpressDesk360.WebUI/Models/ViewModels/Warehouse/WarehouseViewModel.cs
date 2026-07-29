using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Warehouse;

namespace ExpressDesk360.WebUI.Models.ViewModels.Warehouse
{
    public class WarehouseViewModel
    {
        public SelectList? CompanyIds { get; set; }
        public WarehouseFilterModel FilterModel { get; set; } = new WarehouseFilterModel();
    }

    public class WarehouseFilterModel
    {
        public bool IsActive { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
    }
}