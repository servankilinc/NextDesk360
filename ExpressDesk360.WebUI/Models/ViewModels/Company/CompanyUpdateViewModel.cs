using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyModule.Company.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Company
{
    public class CompanyUpdateViewModel
    {
        public CompanyUpdateDto UpdateModel { get; set; } = new CompanyUpdateDto();
    }
}