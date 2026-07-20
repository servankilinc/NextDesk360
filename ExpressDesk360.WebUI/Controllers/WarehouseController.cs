using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Warehouse;
using ExpressDesk360.Model.Dtos.Warehouse.Commands;
using ExpressDesk360.Model.Dtos.Warehouse.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class WarehouseController : BaseController
    {
        private readonly IWarehouseService _warehouseService;
        private readonly ICompanyService _companyService;
        public WarehouseController(ILogger<WarehouseController> logger, IWarehouseService warehouseService, ICompanyService companyService) : base(logger)
        {
            _warehouseService = warehouseService;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyIds = await _companyService.SelectListAsync();
            var viewModel = new WarehouseViewModel
            {
                CompanyIds = companyIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyIds = await _companyService.SelectListAsync();
            var viewModel = new WarehouseCreateViewModel
            {
                CompanyIds = companyIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarehouseCreateDto createModel)
        {
            var result = await _warehouseService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _warehouseService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyIds = await _companyService.SelectListAsync();
            var viewModel = new WarehouseUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyIds = companyIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WarehouseUpdateDto updateModel)
        {
            var result = await _warehouseService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _warehouseService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _warehouseService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _warehouseService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _warehouseService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}