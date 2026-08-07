using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyFile
{
    public class CompanyFileCreateViewModel
    {
        public CompanyFileCreateDto CreateModel { get; set; } = new CompanyFileCreateDto();
        public SelectList? CompanyIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}