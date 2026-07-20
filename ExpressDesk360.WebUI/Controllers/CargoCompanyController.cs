using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.CargoCompany;
using ExpressDesk360.Model.Dtos.CargoCompany.Commands;
using ExpressDesk360.Model.Dtos.CargoCompany.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CargoCompanyController : BaseController
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ILogger<CargoCompanyController> logger, ICargoCompanyService cargoCompanyService) : base(logger)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new CargoCompanyViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CargoCompanyCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CargoCompanyCreateDto request)
        {
            var result = await _cargoCompanyService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _cargoCompanyService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new CargoCompanyUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CargoCompanyUpdateDto updateModel)
        {
            var result = await _cargoCompanyService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cargoCompanyService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _cargoCompanyService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _cargoCompanyService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _cargoCompanyService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}