using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.BOMItem;
using ExpressDesk360.Model.Dtos.BOMItem.Commands;
using ExpressDesk360.Model.Dtos.BOMItem.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class BOMItemController : BaseController
    {
        private readonly IBOMItemService _bOMItemService;
        private readonly IBOMService _bOMService;
        private readonly IStockService _stockService;
        public BOMItemController(ILogger<BOMItemController> logger, IBOMItemService bOMItemService, IBOMService bOMService, IStockService stockService) : base(logger)
        {
            _bOMItemService = bOMItemService;
            _bOMService = bOMService;
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bOMIds = await _bOMService.SelectListAsync();
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new BOMItemViewModel
            {
                BOMIds = bOMIds.Data,
                StockIds = stockIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bOMIds = await _bOMService.SelectListAsync();
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new BOMItemCreateViewModel
            {
                BOMIds = bOMIds.Data,
                StockIds = stockIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BOMItemCreateDto createModel)
        {
            var result = await _bOMItemService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _bOMItemService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var bOMIds = await _bOMService.SelectListAsync();
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new BOMItemUpdateViewModel
            {
                UpdateModel = result.Data,
                BOMIds = bOMIds.Data,
                StockIds = stockIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BOMItemUpdateDto updateModel)
        {
            var result = await _bOMItemService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bOMItemService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _bOMItemService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _bOMItemService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _bOMItemService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}