using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyProductStockSerialMap;
using ExpressDesk360.Model.Dtos.CompanyProductStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.CompanyProductStockSerialMap.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CompanyProductStockSerialMapController : BaseController
    {
        private readonly ICompanyProductStockSerialMapService _companyProductStockSerialMapService;
        private readonly ICompanyProductService _companyProductService;
        private readonly IStockSerialService _stockSerialService;
        public CompanyProductStockSerialMapController(ILogger<CompanyProductStockSerialMapController> logger, ICompanyProductStockSerialMapService companyProductStockSerialMapService, ICompanyProductService companyProductService, IStockSerialService stockSerialService) : base(logger)
        {
            _companyProductStockSerialMapService = companyProductStockSerialMapService;
            _companyProductService = companyProductService;
            _stockSerialService = stockSerialService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new CompanyProductStockSerialMapViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyProductIds = await _companyProductService.SelectListAsync();
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var viewModel = new CompanyProductStockSerialMapCreateViewModel
            {
                CompanyProductIds = companyProductIds.Data,
                StockSerialIds = stockSerialIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyProductStockSerialMapCreateDto request)
        {
            var result = await _companyProductStockSerialMapService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyProductStockSerialMapService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyProductIds = await _companyProductService.SelectListAsync();
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var viewModel = new CompanyProductStockSerialMapUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyProductIds = companyProductIds.Data,
                StockSerialIds = stockSerialIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyProductStockSerialMapUpdateDto updateModel)
        {
            var result = await _companyProductStockSerialMapService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyProductStockSerialMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _companyProductStockSerialMapService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductStockSerialMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductStockSerialMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}