using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Currency.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Currency
{
    public class CurrencyUpdateViewModel
    {
        public CurrencyUpdateDto UpdateModel { get; set; } = new CurrencyUpdateDto();
    }
}