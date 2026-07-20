using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockGroup;
using ExpressDesk360.Model.Dtos.StockGroup.Commands;
using ExpressDesk360.Model.Dtos.StockGroup.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockGroupController : BaseController
    {
        private readonly IStockGroupService _stockGroupService;
        public StockGroupController(ILogger<StockGroupController> logger, IStockGroupService stockGroupService) : base(logger)
        {
            _stockGroupService = stockGroupService;
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
            var viewModel = new StockGroupCreateViewModel
            {
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
            var viewModel = new StockGroupUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockGroupUpdateDto updateModel)
        {
            var result = await _stockGroupService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _stockGroupService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _stockGroupService.RestoreAsync(id: id);
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
    }
}