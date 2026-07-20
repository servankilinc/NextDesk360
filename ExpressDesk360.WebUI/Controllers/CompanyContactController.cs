using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyContact;
using ExpressDesk360.Model.Dtos.CompanyContact.Commands;
using ExpressDesk360.Model.Dtos.CompanyContact.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CompanyContactController : BaseController
    {
        private readonly ICompanyContactService _companyContactService;
        private readonly ICompanyService _companyService;
        private readonly IContactTypeService _contactTypeService;
        public CompanyContactController(ILogger<CompanyContactController> logger, ICompanyContactService companyContactService, ICompanyService companyService, IContactTypeService contactTypeService) : base(logger)
        {
            _companyContactService = companyContactService;
            _companyService = companyService;
            _contactTypeService = contactTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyIds = await _companyService.SelectListAsync();
            var contactTypeIds = await _contactTypeService.SelectListAsync();
            var viewModel = new CompanyContactViewModel
            {
                CompanyIds = companyIds.Data,
                ContactTypeIds = contactTypeIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyIds = await _companyService.SelectListAsync();
            var contactTypeIds = await _contactTypeService.SelectListAsync();
            var viewModel = new CompanyContactCreateViewModel
            {
                CompanyIds = companyIds.Data,
                ContactTypeIds = contactTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyContactCreateDto createModel)
        {
            var result = await _companyContactService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyContactService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyIds = await _companyService.SelectListAsync();
            var contactTypeIds = await _contactTypeService.SelectListAsync();
            var viewModel = new CompanyContactUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyIds = companyIds.Data,
                ContactTypeIds = contactTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyContactUpdateDto updateModel)
        {
            var result = await _companyContactService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyContactService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _companyContactService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyContactService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyContactService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}