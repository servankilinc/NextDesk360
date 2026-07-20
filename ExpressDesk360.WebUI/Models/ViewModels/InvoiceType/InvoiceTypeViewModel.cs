using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.InvoiceType;

namespace ExpressDesk360.WebUI.Models.ViewModels.InvoiceType
{
    public class InvoiceTypeViewModel
    {
        public InvoiceTypeFilterModel FilterModel { get; set; } = new InvoiceTypeFilterModel();
    }

    public class InvoiceTypeFilterModel
    {
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}