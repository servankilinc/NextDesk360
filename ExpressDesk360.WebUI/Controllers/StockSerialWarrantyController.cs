using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockSerialWarranty;
using ExpressDesk360.Model.Dtos.StockSerialWarranty.Commands;
using ExpressDesk360.Model.Dtos.StockSerialWarranty.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockSerialWarrantyController : BaseController
    {
        private readonly IStockSerialWarrantyService _stockSerialWarrantyService;
        private readonly IStockSerialService _stockSerialService;
        private readonly IWarrantyTypeService _warrantyTypeService;
        public StockSerialWarrantyController(ILogger<StockSerialWarrantyController> logger, IStockSerialWarrantyService stockSerialWarrantyService, IStockSerialService stockSerialService, IWarrantyTypeService warrantyTypeService) : base(logger)
        {
            _stockSerialWarrantyService = stockSerialWarrantyService;
            _stockSerialService = stockSerialService;
            _warrantyTypeService = warrantyTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var warrantyTypeIds = await _warrantyTypeService.SelectListAsync();
            var viewModel = new StockSerialWarrantyViewModel
            {
                StockSerialIds = stockSerialIds.Data,
                WarrantyTypeIds = warrantyTypeIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var warrantyTypeIds = await _warrantyTypeService.SelectListAsync();
            var viewModel = new StockSerialWarrantyCreateViewModel
            {
                StockSerialIds = stockSerialIds.Data,
                WarrantyTypeIds = warrantyTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockSerialWarrantyCreateDto request)
        {
            var result = await _stockSerialWarrantyService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockSerialWarrantyService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var stockSerialIds = await _stockSerialService.SelectListAsync();
            var warrantyTypeIds = await _warrantyTypeService.SelectListAsync();
            var viewModel = new StockSerialWarrantyUpdateViewModel
            {
                UpdateModel = result.Data,
                StockSerialIds = stockSerialIds.Data,
                WarrantyTypeIds = warrantyTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StockSerialWarrantyUpdateDto updateModel)
        {
            var result = await _stockSerialWarrantyService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockSerialWarrantyService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _stockSerialWarrantyService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockSerialWarrantyService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockSerialWarrantyService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}