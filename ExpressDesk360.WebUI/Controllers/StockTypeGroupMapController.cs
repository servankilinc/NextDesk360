using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockTypeGroupMap;
using ExpressDesk360.Model.Dtos.StockTypeGroupMap.Commands;
using ExpressDesk360.Model.Dtos.StockTypeGroupMap.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockTypeGroupMapController : BaseController
    {
        private readonly IStockTypeGroupMapService _stockTypeGroupMapService;
        private readonly IStockTypeService _stockTypeService;
        private readonly IStockGroupService _stockGroupService;
        public StockTypeGroupMapController(ILogger<StockTypeGroupMapController> logger, IStockTypeGroupMapService stockTypeGroupMapService, IStockTypeService stockTypeService, IStockGroupService stockGroupService) : base(logger)
        {
            _stockTypeGroupMapService = stockTypeGroupMapService;
            _stockTypeService = stockTypeService;
            _stockGroupService = stockGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockTypeGroupMapViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockTypeIds = await _stockTypeService.SelectListAsync();
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var viewModel = new StockTypeGroupMapCreateViewModel
            {
                StockTypeIds = stockTypeIds.Data,
                StockGroupIds = stockGroupIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockTypeGroupMapCreateDto createModel)
        {
            var result = await _stockTypeGroupMapService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockTypeGroupMapService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockTypeIds = await _stockTypeService.SelectListAsync();
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var viewModel = new StockTypeGroupMapUpdateViewModel
            {
                UpdateModel = result.Data,
                StockTypeIds = stockTypeIds.Data,
                StockGroupIds = stockGroupIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockTypeGroupMapUpdateDto updateModel)
        {
            var result = await _stockTypeGroupMapService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockTypeGroupMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockTypeGroupMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockTypeGroupMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}