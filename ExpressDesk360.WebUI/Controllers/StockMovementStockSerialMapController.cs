using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockMovementStockSerialMap;
using ExpressDesk360.Model.Dtos.StockMovementStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.StockMovementStockSerialMap.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockMovementStockSerialMapController : BaseController
    {
        private readonly IStockMovementStockSerialMapService _stockMovementStockSerialMapService;
        private readonly IStockSerialService _stockSerialService;
        private readonly IStockMovementService _stockMovementService;
        public StockMovementStockSerialMapController(ILogger<StockMovementStockSerialMapController> logger, IStockMovementStockSerialMapService stockMovementStockSerialMapService, IStockSerialService stockSerialService, IStockMovementService stockMovementService) : base(logger)
        {
            _stockMovementStockSerialMapService = stockMovementStockSerialMapService;
            _stockSerialService = stockSerialService;
            _stockMovementService = stockMovementService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockMovementStockSerialMapViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var stockMovementIds = await _stockMovementService.SelectListAsync();
            var viewModel = new StockMovementStockSerialMapCreateViewModel
            {
                StockSerialIds = stockSerialIds.Data,
                StockMovementIds = stockMovementIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockMovementStockSerialMapCreateDto createModel)
        {
            var result = await _stockMovementStockSerialMapService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var stockMovementIds = await _stockMovementService.SelectListAsync();
            var viewModel = new StockMovementStockSerialMapUpdateViewModel
            {
                UpdateModel = result.Data,
                StockSerialIds = stockSerialIds.Data,
                StockMovementIds = stockMovementIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockMovementStockSerialMapUpdateDto updateModel)
        {
            var result = await _stockMovementStockSerialMapService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementStockSerialMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementStockSerialMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}