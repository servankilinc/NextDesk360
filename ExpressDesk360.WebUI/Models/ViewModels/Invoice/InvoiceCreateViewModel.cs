using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Invoice.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Invoice
{
    public class InvoiceCreateViewModel
    {
        public InvoiceCreateDto CreateModel { get; set; } = new InvoiceCreateDto();
        public SelectList? InvoiceTypeIds { get; set; }
        public SelectList? SellerCompanyIds { get; set; }
        public SelectList? BuyerCompanyIds { get; set; }
        public SelectList? CurrencyIds { get; set; }
    }
}