using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyProduct;
using ExpressDesk360.Model.Dtos.CompanyProduct.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProduct.Commands;
using ExpressDesk360.Business.Abstract.ProductionModule;
using ExpressDesk360.Business.Abstract.CompanyModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CompanyProductController : BaseController
    {
        private readonly ICompanyProductService _companyProductService;
        private readonly ICompanyService _companyService;
        private readonly IStockService _stockService;
        private readonly IBOMService _bOMService;
        public CompanyProductController(ILogger<CompanyProductController> logger, ICompanyProductService companyProductService, ICompanyService companyService, IStockService stockService, IBOMService bOMService) : base(logger)
        {
            _companyProductService = companyProductService;
            _companyService = companyService;
            _stockService = stockService;
            _bOMService = bOMService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyIds = await _companyService.SelectListAsync();
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new CompanyProductViewModel
            {
                CompanyIds = companyIds.Data,
                StockIds = stockIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyIds = await _companyService.SelectListAsync();
            var stockIds = await _stockService.SelectListAsync();
            var bOMIds = await _bOMService.SelectListAsync();
            var viewModel = new CompanyProductCreateViewModel
            {
                CompanyIds = companyIds.Data,
                StockIds = stockIds.Data,
                BOMIds = bOMIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyProductCreateDto createModel)
        {
            var result = await _companyProductService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyProductService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyIds = await _companyService.SelectListAsync();
            var stockIds = await _stockService.SelectListAsync();
            var bOMIds = await _bOMService.SelectListAsync();
            var viewModel = new CompanyProductUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyIds = companyIds.Data,
                StockIds = stockIds.Data,
                BOMIds = bOMIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyProductUpdateDto updateModel)
        {
            var result = await _companyProductService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyProductService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _companyProductService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}