using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.Currency;

namespace ExpressDesk360.WebUI.Models.ViewModels.Currency
{
    public class CurrencyViewModel
    {
        public CurrencyFilterModel FilterModel { get; set; } = new CurrencyFilterModel();
    }

    public class CurrencyFilterModel
    {
        public bool IsActive { get; set; }
        public string? Name { get; set; }
    }
}