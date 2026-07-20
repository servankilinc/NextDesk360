using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.WarrantyType.Commands;
using ExpressDesk360.Model.Dtos.WarrantyType.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class WarrantyTypeController : BaseController
    {
        private readonly IWarrantyTypeService _warrantyTypeService;
        public WarrantyTypeController(ILogger<WarrantyTypeController> logger, IWarrantyTypeService warrantyTypeService) : base(logger)
        {
            _warrantyTypeService = warrantyTypeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _warrantyTypeService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _warrantyTypeService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _warrantyTypeService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _warrantyTypeService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarrantyTypeCreateDto request)
        {
            var result = await _warrantyTypeService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _warrantyTypeService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(WarrantyTypeUpdateDto request)
        {
            var result = await _warrantyTypeService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _warrantyTypeService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _warrantyTypeService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _warrantyTypeService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _warrantyTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _warrantyTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}