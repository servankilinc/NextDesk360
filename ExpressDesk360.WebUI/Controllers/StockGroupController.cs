using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroup;
using ExpressDesk360.Model.Dtos.StockGroup.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockGroup.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockGroupController : BaseController
    {
        private readonly IStockGroupService _stockGroupService;
        private readonly IStockBrandService _stockBrandService;
        private readonly IFaultTypeService _faultTypeService;

        public StockGroupController(ILogger<StockGroupController> logger, IStockGroupService stockGroupService, IStockBrandService stockBrandService, IFaultTypeService faultTypeService) : base(logger)
        {
            _stockGroupService = stockGroupService;
            _stockBrandService = stockBrandService;
            _faultTypeService = faultTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockGroupViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brandsResult = await _stockBrandService.SelectListAsync();
            var faultTypesResult = await _faultTypeService.SelectListAsync();

            var viewModel = new StockGroupCreateViewModel
            {
                BrandIds = brandsResult.Data,
                FaultTypeIds = faultTypesResult.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockGroupCreateDto createModel)
        {
            var result = await _stockGroupService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _stockGroupService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var brandsResult = await _stockBrandService.SelectListAsync();
            var faultTypesResult = await _faultTypeService.SelectListAsync();

            var viewModel = new StockGroupUpdateViewModel
            {
                UpdateModel = result.Data,
                BrandIds = brandsResult.Data,
                FaultTypeIds = faultTypesResult.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockGroupUpdateDto updateModel)
        {
            var result = await _stockGroupService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupService.DatatableServerSideAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _stockGroupService.GetDetailAsync(id);
            if (!result.IsSuccess) return ToAction(result);

            var viewModel = new StockGroupDetailViewModel
            {
                StockGroup = result.Data
            };
            return View(viewModel);
        }
    }
}