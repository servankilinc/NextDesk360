using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.InvoiceModule.InvoiceType.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.InvoiceType
{
    public class InvoiceTypeCreateViewModel
    {
        public InvoiceTypeCreateDto CreateModel { get; set; } = new InvoiceTypeCreateDto();
    }
}