using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.WarrantyType;
using ExpressDesk360.Model.Dtos.WarrantyType.Commands;
using ExpressDesk360.Model.Dtos.WarrantyType.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class WarrantyTypeController : BaseController
    {
        private readonly IWarrantyTypeService _warrantyTypeService;
        public WarrantyTypeController(ILogger<WarrantyTypeController> logger, IWarrantyTypeService warrantyTypeService) : base(logger)
        {
            _warrantyTypeService = warrantyTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new WarrantyTypeViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new WarrantyTypeCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarrantyTypeCreateDto createModel)
        {
            var result = await _warrantyTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _warrantyTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new WarrantyTypeUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WarrantyTypeUpdateDto updateModel)
        {
            var result = await _warrantyTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _warrantyTypeService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _warrantyTypeService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _warrantyTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _warrantyTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}