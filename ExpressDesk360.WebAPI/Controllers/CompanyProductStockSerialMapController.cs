using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.CompanyProductStockSerialMap.Queries;
using ExpressDesk360.Model.Dtos.ProductionModule.CompanyProductStockSerialMap.Commands;
using ExpressDesk360.Business.Abstract.ProductionModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class CompanyProductStockSerialMapController : BaseController
    {
        private readonly ICompanyProductStockSerialMapService _companyProductStockSerialMapService;
        public CompanyProductStockSerialMapController(ILogger<CompanyProductStockSerialMapController> logger, ICompanyProductStockSerialMapService companyProductStockSerialMapService) : base(logger)
        {
            _companyProductStockSerialMapService = companyProductStockSerialMapService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _companyProductStockSerialMapService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _companyProductStockSerialMapService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _companyProductStockSerialMapService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _companyProductStockSerialMapService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyProductStockSerialMapCreateDto request)
        {
            var result = await _companyProductStockSerialMapService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _companyProductStockSerialMapService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyProductStockSerialMapUpdateDto request)
        {
            var result = await _companyProductStockSerialMapService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyProductStockSerialMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _companyProductStockSerialMapService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductStockSerialMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _companyProductStockSerialMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}