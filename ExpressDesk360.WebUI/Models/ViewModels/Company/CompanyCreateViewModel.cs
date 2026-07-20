using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Company.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Company
{
    public class CompanyCreateViewModel
    {
        public CompanyCreateDto CreateModel { get; set; } = new CompanyCreateDto();
    }
}