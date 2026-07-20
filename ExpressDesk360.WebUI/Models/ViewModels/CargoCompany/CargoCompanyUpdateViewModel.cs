using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.CargoCompany.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.CargoCompany
{
    public class CargoCompanyUpdateViewModel
    {
        public CargoCompanyUpdateDto UpdateModel { get; set; } = new CargoCompanyUpdateDto();
    }
}