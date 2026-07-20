using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.CompanyFile;
using ExpressDesk360.Model.Dtos.CompanyFile.Commands;
using ExpressDesk360.Model.Dtos.CompanyFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CompanyFileController : BaseController
    {
        private readonly ICompanyFileService _companyFileService;
        private readonly ICompanyService _companyService;
        private readonly IFSFileService _fSFileService;
        public CompanyFileController(ILogger<CompanyFileController> logger, ICompanyFileService companyFileService, ICompanyService companyService, IFSFileService fSFileService) : base(logger)
        {
            _companyFileService = companyFileService;
            _companyService = companyService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyIds = await _companyService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new CompanyFileViewModel
            {
                CompanyIds = companyIds.Data,
                FileIds = fileIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyIds = await _companyService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new CompanyFileCreateViewModel
            {
                CompanyIds = companyIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyFileCreateDto request)
        {
            var result = await _companyFileService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyIds = await _companyService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new CompanyFileUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyIds = companyIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyFileUpdateDto updateModel)
        {
            var result = await _companyFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _companyFileService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}