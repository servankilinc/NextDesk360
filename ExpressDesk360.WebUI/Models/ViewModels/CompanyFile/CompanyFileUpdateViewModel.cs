using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyFile.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyFile
{
    public class CompanyFileUpdateViewModel
    {
        public CompanyFileUpdateDto UpdateModel { get; set; } = new CompanyFileUpdateDto();
        public SelectList? CompanyIds { get; set; }
        public SelectList? FileIds { get; set; }
    }
}