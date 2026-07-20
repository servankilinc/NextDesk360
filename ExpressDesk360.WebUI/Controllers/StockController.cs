using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Stock;
using ExpressDesk360.Model.Dtos.Stock.Commands;
using ExpressDesk360.Model.Dtos.Stock.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockController : BaseController
    {
        private readonly IStockService _stockService;
        private readonly IStockGroupService _stockGroupService;
        private readonly IStockBrandService _stockBrandService;
        private readonly IUnitService _unitService;
        private readonly ICurrencyService _currencyService;
        public StockController(ILogger<StockController> logger, IStockService stockService, IStockGroupService stockGroupService, IStockBrandService stockBrandService, IUnitService unitService, ICurrencyService currencyService) : base(logger)
        {
            _stockService = stockService;
            _stockGroupService = stockGroupService;
            _stockBrandService = stockBrandService;
            _unitService = unitService;
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var stockBrandIds = await _stockBrandService.SelectListAsync();
            var viewModel = new StockViewModel
            {
                StockGroupIds = stockGroupIds.Data,
                StockBrandIds = stockBrandIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var stockBrandIds = await _stockBrandService.SelectListAsync();
            var unitIds = await _unitService.SelectListAsync();
            var purchaseCurrencyIds = await _currencyService.SelectListAsync();
            var salePriceCurrencyIds = await _currencyService.SelectListAsync();
            var viewModel = new StockCreateViewModel
            {
                StockGroupIds = stockGroupIds.Data,
                StockBrandIds = stockBrandIds.Data,
                UnitIds = unitIds.Data,
                PurchaseCurrencyIds = purchaseCurrencyIds.Data,
                SalePriceCurrencyIds = salePriceCurrencyIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockCreateDto request)
        {
            var result = await _stockService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var stockBrandIds = await _stockBrandService.SelectListAsync();
            var unitIds = await _unitService.SelectListAsync();
            var purchaseCurrencyIds = await _currencyService.SelectListAsync();
            var salePriceCurrencyIds = await _currencyService.SelectListAsync();
            var viewModel = new StockUpdateViewModel
            {
                UpdateModel = result.Data,
                StockGroupIds = stockGroupIds.Data,
                StockBrandIds = stockBrandIds.Data,
                UnitIds = unitIds.Data,
                PurchaseCurrencyIds = purchaseCurrencyIds.Data,
                SalePriceCurrencyIds = salePriceCurrencyIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockUpdateDto updateModel)
        {
            var result = await _stockService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _stockService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}