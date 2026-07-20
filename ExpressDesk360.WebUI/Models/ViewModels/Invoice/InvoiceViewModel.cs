using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Invoice;

namespace ExpressDesk360.WebUI.Models.ViewModels.Invoice
{
    public class InvoiceViewModel
    {
        public SelectList? InvoiceTypeIds { get; set; }
        public SelectList? SellerCompanyIds { get; set; }
        public SelectList? BuyerCompanyIds { get; set; }
        public InvoiceFilterModel FilterModel { get; set; } = new InvoiceFilterModel();
    }

    public class InvoiceFilterModel
    {
        public int InvoiceTypeId { get; set; }
        public string? InvoiceNo { get; set; }
        public Guid SellerCompanyId { get; set; }
        public Guid BuyerCompanyId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}