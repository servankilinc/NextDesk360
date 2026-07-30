using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockSerial;
using ExpressDesk360.Model.Dtos.StockSerial.Commands;
using ExpressDesk360.Model.Dtos.StockSerial.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockSerialController : BaseController
    {
        private readonly IStockSerialService _stockSerialService;
        private readonly IStockService _stockService;
        private readonly ICompanyService _companyService;
        private readonly IWarehouseService _warehouseService;
        public StockSerialController(ILogger<StockSerialController> logger, IStockSerialService stockSerialService, IStockService stockService, ICompanyService companyService, IWarehouseService warehouseService) : base(logger)
        {
            _stockSerialService = stockSerialService;
            _stockService = stockService;
            _companyService = companyService;
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockIds = await _stockService.SelectListAsync();
            var companyIds = await _companyService.SelectListAsync();
            var warehouseIds = await _warehouseService.SelectListAsync();
            var viewModel = new StockSerialViewModel
            {
                StockIds = stockIds.Data,
                CompanyIds = companyIds.Data,
                WarehouseIds = warehouseIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockIds = await _stockService.SelectListAsync();
            var companyIds = await _companyService.SelectListAsync();
            var warehouseIds = await _warehouseService.SelectListAsync();
            var viewModel = new StockSerialCreateViewModel
            {
                StockIds = stockIds.Data,
                CompanyIds = companyIds.Data,
                WarehouseIds = warehouseIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockSerialCreateDto createModel)
        {
            var result = await _stockSerialService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockSerialService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockIds = await _stockService.SelectListAsync();
            var companyIds = await _companyService.SelectListAsync();
            var warehouseIds = await _warehouseService.SelectListAsync();
            var viewModel = new StockSerialUpdateViewModel
            {
                UpdateModel = result.Data,
                StockIds = stockIds.Data,
                CompanyIds = companyIds.Data,
                WarehouseIds = warehouseIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockSerialUpdateDto updateModel)
        {
            var result = await _stockSerialService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockSerialService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockSerialService.DatatableServerSideAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _stockSerialService.GetDetailAsync(id);
            if (!result.IsSuccess) return ToAction(result);

            var viewModel = new StockSerialDetailViewModel
            {
                StockSerial = result.Data
            };
            return View(viewModel);
        }
    }
}