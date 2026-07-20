using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyProductWarranty;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Commands;
using ExpressDesk360.Model.Dtos.CompanyProductWarranty.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CompanyProductWarrantyController : BaseController
    {
        private readonly ICompanyProductWarrantyService _companyProductWarrantyService;
        private readonly ICompanyProductService _companyProductService;
        private readonly IWarrantyTypeService _warrantyTypeService;
        public CompanyProductWarrantyController(ILogger<CompanyProductWarrantyController> logger, ICompanyProductWarrantyService companyProductWarrantyService, ICompanyProductService companyProductService, IWarrantyTypeService warrantyTypeService) : base(logger)
        {
            _companyProductWarrantyService = companyProductWarrantyService;
            _companyProductService = companyProductService;
            _warrantyTypeService = warrantyTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyProductIds = await _companyProductService.SelectListAsync();
            var warrantyTypeIds = await _warrantyTypeService.SelectListAsync();
            var viewModel = new CompanyProductWarrantyViewModel
            {
                CompanyProductIds = companyProductIds.Data,
                WarrantyTypeIds = warrantyTypeIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyProductIds = await _companyProductService.SelectListAsync();
            var warrantyTypeIds = await _warrantyTypeService.SelectListAsync();
            var viewModel = new CompanyProductWarrantyCreateViewModel
            {
                CompanyProductIds = companyProductIds.Data,
                WarrantyTypeIds = warrantyTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyProductWarrantyCreateDto createModel)
        {
            var result = await _companyProductWarrantyService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyProductWarrantyService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyProductIds = await _companyProductService.SelectListAsync();
            var warrantyTypeIds = await _warrantyTypeService.SelectListAsync();
            var viewModel = new CompanyProductWarrantyUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyProductIds = companyProductIds.Data,
                WarrantyTypeIds = warrantyTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyProductWarrantyUpdateDto updateModel)
        {
            var result = await _companyProductWarrantyService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyProductWarrantyService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _companyProductWarrantyService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductWarrantyService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductWarrantyService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}