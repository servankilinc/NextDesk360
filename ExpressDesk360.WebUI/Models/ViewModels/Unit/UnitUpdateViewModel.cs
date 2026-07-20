using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Model.Dtos.Unit.Commands;

namespace ExpressDesk360.WebUI.Models.ViewModels.Unit
{
    public class UnitUpdateViewModel
    {
        public UnitUpdateDto UpdateModel { get; set; } = new UnitUpdateDto();
    }
}