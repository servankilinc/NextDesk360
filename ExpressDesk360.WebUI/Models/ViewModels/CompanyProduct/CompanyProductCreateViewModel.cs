using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProduct.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProduct
{
    public class CompanyProductCreateViewModel
    {
        public CompanyProductCreateDto CreateModel { get; set; } = new CompanyProductCreateDto();
        public SelectList? CompanyIds { get; set; }
        public SelectList? StockIds { get; set; }
        public SelectList? BOMIds { get; set; }
    }
}