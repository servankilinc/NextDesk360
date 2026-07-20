using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.ShippingFile;
using ExpressDesk360.Model.Dtos.ShippingFile.Commands;
using ExpressDesk360.Model.Dtos.ShippingFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ShippingFileController : BaseController
    {
        private readonly IShippingFileService _shippingFileService;
        private readonly IShippingService _shippingService;
        private readonly IFSFileService _fSFileService;
        public ShippingFileController(ILogger<ShippingFileController> logger, IShippingFileService shippingFileService, IShippingService shippingService, IFSFileService fSFileService) : base(logger)
        {
            _shippingFileService = shippingFileService;
            _shippingService = shippingService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shippingIds = await _shippingService.SelectListAsync();
            var viewModel = new ShippingFileViewModel
            {
                ShippingIds = shippingIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var shippingIds = await _shippingService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new ShippingFileCreateViewModel
            {
                ShippingIds = shippingIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShippingFileCreateDto request)
        {
            var result = await _shippingFileService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _shippingFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var shippingIds = await _shippingService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new ShippingFileUpdateViewModel
            {
                UpdateModel = result.Data,
                ShippingIds = shippingIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ShippingFileUpdateDto updateModel)
        {
            var result = await _shippingFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _shippingFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _shippingFileService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _shippingFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _shippingFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}