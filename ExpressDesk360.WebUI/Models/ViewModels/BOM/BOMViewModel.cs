using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.BOM;

namespace ExpressDesk360.WebUI.Models.ViewModels.BOM
{
    public class BOMViewModel
    {
        public SelectList? StockIds { get; set; }
        public BOMFilterModel FilterModel { get; set; } = new BOMFilterModel();
    }

    public class BOMFilterModel
    {
        public Guid StockId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}