using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.CompanyFile.Queries;
using ExpressDesk360.Model.Dtos.CompanyModule.CompanyFile.Commands;
using ExpressDesk360.Business.Abstract.CompanyModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class CompanyFileController : BaseController
    {
        private readonly ICompanyFileService _companyFileService;
        public CompanyFileController(ILogger<CompanyFileController> logger, ICompanyFileService companyFileService) : base(logger)
        {
            _companyFileService = companyFileService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _companyFileService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _companyFileService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _companyFileService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _companyFileService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyFileCreateDto request)
        {
            var result = await _companyFileService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyFileService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyFileUpdateDto request)
        {
            var result = await _companyFileService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _companyFileService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}