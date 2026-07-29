using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroupFaultTypeMap;
using ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Commands;
using ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockGroupFaultTypeMapController : BaseController
    {
        private readonly IStockGroupFaultTypeMapService _stockGroupFaultTypeMapService;
        private readonly IFaultTypeService _faultTypeService;
        private readonly IStockGroupService _stockGroupService;
        public StockGroupFaultTypeMapController(ILogger<StockGroupFaultTypeMapController> logger, IStockGroupFaultTypeMapService stockGroupFaultTypeMapService, IFaultTypeService faultTypeService, IStockGroupService stockGroupService) : base(logger)
        {
            _stockGroupFaultTypeMapService = stockGroupFaultTypeMapService;
            _faultTypeService = faultTypeService;
            _stockGroupService = stockGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockGroupFaultTypeMapViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var faultTypeIds = await _faultTypeService.SelectListAsync();
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var viewModel = new StockGroupFaultTypeMapCreateViewModel
            {
                FaultTypeIds = faultTypeIds.Data,
                StockGroupIds = stockGroupIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockGroupFaultTypeMapCreateDto createModel)
        {
            var result = await _stockGroupFaultTypeMapService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockGroupFaultTypeMapService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var faultTypeIds = await _faultTypeService.SelectListAsync();
            var stockGroupIds = await _stockGroupService.SelectListAsync();
            var viewModel = new StockGroupFaultTypeMapUpdateViewModel
            {
                UpdateModel = result.Data,
                FaultTypeIds = faultTypeIds.Data,
                StockGroupIds = stockGroupIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockGroupFaultTypeMapUpdateDto updateModel)
        {
            var result = await _stockGroupFaultTypeMapService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockGroupFaultTypeMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupFaultTypeMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupFaultTypeMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}