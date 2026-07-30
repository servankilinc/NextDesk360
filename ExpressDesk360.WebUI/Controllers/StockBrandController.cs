using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockBrand;
using ExpressDesk360.Model.Dtos.StockBrand.Commands;
using ExpressDesk360.Model.Dtos.StockBrand.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockBrandController : BaseController
    {
        private readonly IStockBrandService _stockBrandService;
        public StockBrandController(ILogger<StockBrandController> logger, IStockBrandService stockBrandService) : base(logger)
        {
            _stockBrandService = stockBrandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new StockBrandViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new StockBrandCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockBrandCreateDto createModel)
        {
            var result = await _stockBrandService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _stockBrandService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new StockBrandUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockBrandUpdateDto updateModel)
        {
            var result = await _stockBrandService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockBrandService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockBrandService.DatatableServerSideAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _stockBrandService.GetDetailAsync(id);
            if (!result.IsSuccess) return ToAction(result);

            var viewModel = new StockBrandDetailViewModel
            {
                StockBrand = result.Data
            };
            return View(viewModel);
        }
    }
}