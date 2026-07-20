using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.BOMItem;

namespace ExpressDesk360.WebUI.Models.ViewModels.BOMItem
{
    public class BOMItemViewModel
    {
        public SelectList? BOMIds { get; set; }
        public SelectList? StockIds { get; set; }
        public BOMItemFilterModel FilterModel { get; set; } = new BOMItemFilterModel();
    }

    public class BOMItemFilterModel
    {
        public Guid BOMId { get; set; }
        public Guid StockId { get; set; }
        public bool IsDeleted { get; set; }
    }
}