using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.InvoiceType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.InvoiceType
{
    public class InvoiceTypeUpdateViewModel
    {
        public InvoiceTypeUpdateDto UpdateModel { get; set; } = new InvoiceTypeUpdateDto();
    }
}