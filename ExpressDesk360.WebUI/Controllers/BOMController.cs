using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.BOM;
using ExpressDesk360.Model.Dtos.BOM.Commands;
using ExpressDesk360.Model.Dtos.BOM.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class BOMController : BaseController
    {
        private readonly IBOMService _bOMService;
        private readonly IStockService _stockService;
        public BOMController(ILogger<BOMController> logger, IBOMService bOMService, IStockService stockService) : base(logger)
        {
            _bOMService = bOMService;
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new BOMViewModel
            {
                StockIds = stockIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new BOMCreateViewModel
            {
                StockIds = stockIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BOMCreateDto createModel)
        {
            var result = await _bOMService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _bOMService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockIds = await _stockService.SelectListAsync();
            var viewModel = new BOMUpdateViewModel
            {
                UpdateModel = result.Data,
                StockIds = stockIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BOMUpdateDto updateModel)
        {
            var result = await _bOMService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bOMService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _bOMService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _bOMService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _bOMService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}