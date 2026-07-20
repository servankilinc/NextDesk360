using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Warehouse.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Warehouse
{
    public class WarehouseCreateViewModel
    {
        public WarehouseCreateDto CreateModel { get; set; } = new WarehouseCreateDto();
        public SelectList? CompanyIds { get; set; }
    }
}