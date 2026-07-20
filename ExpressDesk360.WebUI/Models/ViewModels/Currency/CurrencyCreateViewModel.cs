using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Currency.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Currency
{
    public class CurrencyCreateViewModel
    {
        public CurrencyCreateDto CreateModel { get; set; } = new CurrencyCreateDto();
    }
}