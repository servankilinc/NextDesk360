using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockSerialWarranty;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockSerialWarranty
{
    public class StockSerialWarrantyViewModel
    {
        public SelectList? StockSerialIds { get; set; }
        public SelectList? WarrantyTypeIds { get; set; }
        public StockSerialWarrantyFilterModel FilterModel { get; set; } = new StockSerialWarrantyFilterModel();
    }

    public class StockSerialWarrantyFilterModel
    {
        public Guid StockSerialId { get; set; }
        public int WarrantyTypeId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}