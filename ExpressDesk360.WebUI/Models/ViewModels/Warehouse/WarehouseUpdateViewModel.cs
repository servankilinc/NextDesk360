using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Warehouse.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Warehouse
{
    public class WarehouseUpdateViewModel
    {
        public WarehouseUpdateDto UpdateModel { get; set; } = new WarehouseUpdateDto();
        public SelectList? CompanyIds { get; set; }
    }
}