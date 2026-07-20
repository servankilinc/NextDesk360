using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroupBrandMap;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Commands;
using ExpressDesk360.Model.Dtos.StockGroupBrandMap.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockGroupBrandMapController : BaseController
    {
        private readonly IStockGroupBrandMapService _stockGroupBrandMapService;
        private readonly IStockBrandService _stockBrandService;
        private readonly IStockGroupService _stockGroupService;
        public StockGroupBrandMapController(ILogger<StockGroupBrandMapController> logger, IStockGroupBrandMapService stockGroupBrandMapService, IStockBrandService stockBrandService, IStockGroupService stockGroupService) : base(logger)
        {
            _stockGroupBrandMapService = stockGroupBrandMapService;
            _stockBrandService = stockBrandService;
            _stockGroupService = stockGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockGroupBrandMapViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockBrandIds = await _stockBrandService.SelectListAsync();
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var viewModel = new StockGroupBrandMapCreateViewModel
            {
                StockBrandIds = stockBrandIds.Data,
                StockGroupIds = stockGroupIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockGroupBrandMapCreateDto createModel)
        {
            var result = await _stockGroupBrandMapService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockGroupBrandMapService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockBrandIds = await _stockBrandService.SelectListAsync();
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var viewModel = new StockGroupBrandMapUpdateViewModel
            {
                UpdateModel = result.Data,
                StockBrandIds = stockBrandIds.Data,
                StockGroupIds = stockGroupIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockGroupBrandMapUpdateDto updateModel)
        {
            var result = await _stockGroupBrandMapService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockGroupBrandMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _stockGroupBrandMapService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupBrandMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupBrandMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}