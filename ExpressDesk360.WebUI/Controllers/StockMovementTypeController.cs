using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockMovementType;
using ExpressDesk360.Model.Dtos.StockMovementType.Commands;
using ExpressDesk360.Model.Dtos.StockMovementType.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockMovementTypeController : BaseController
    {
        private readonly IStockMovementTypeService _stockMovementTypeService;
        public StockMovementTypeController(ILogger<StockMovementTypeController> logger, IStockMovementTypeService stockMovementTypeService) : base(logger)
        {
            _stockMovementTypeService = stockMovementTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockMovementTypeViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new StockMovementTypeCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockMovementTypeCreateDto createModel)
        {
            var result = await _stockMovementTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _stockMovementTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new StockMovementTypeUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockMovementTypeUpdateDto updateModel)
        {
            var result = await _stockMovementTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}