using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.InvoiceModule.Invoice.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Invoice
{
    public class InvoiceUpdateViewModel
    {
        public InvoiceUpdateDto UpdateModel { get; set; } = new InvoiceUpdateDto();
        public SelectList? InvoiceTypeIds { get; set; }
        public SelectList? SellerCompanyIds { get; set; }
        public SelectList? BuyerCompanyIds { get; set; }
        public SelectList? CurrencyIds { get; set; }
    }
}