using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ShippingFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.ShippingFile
{
    public class ShippingFileViewModel
    {
        public SelectList? ShippingIds { get; set; }
        public ShippingFileFilterModel FilterModel { get; set; } = new ShippingFileFilterModel();
    }

    public class ShippingFileFilterModel
    {
        public Guid ShippingId { get; set; }
        public bool IsDeleted { get; set; }
    }
}