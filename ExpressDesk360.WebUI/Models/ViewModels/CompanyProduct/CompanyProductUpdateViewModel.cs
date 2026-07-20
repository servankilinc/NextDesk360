using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CompanyProduct.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CompanyProduct
{
    public class CompanyProductUpdateViewModel
    {
        public CompanyProductUpdateDto UpdateModel { get; set; } = new CompanyProductUpdateDto();
        public SelectList? CompanyIds { get; set; }
        public SelectList? StockIds { get; set; }
        public SelectList? BOMIds { get; set; }
    }
}