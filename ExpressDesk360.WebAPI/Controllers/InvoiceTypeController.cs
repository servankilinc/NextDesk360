using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.InvoiceType.Commands;
using ExpressDesk360.Model.Dtos.InvoiceType.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class InvoiceTypeController : BaseController
    {
        private readonly IInvoiceTypeService _invoiceTypeService;
        public InvoiceTypeController(ILogger<InvoiceTypeController> logger, IInvoiceTypeService invoiceTypeService) : base(logger)
        {
            _invoiceTypeService = invoiceTypeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _invoiceTypeService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _invoiceTypeService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _invoiceTypeService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _invoiceTypeService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceTypeCreateDto request)
        {
            var result = await _invoiceTypeService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _invoiceTypeService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(InvoiceTypeUpdateDto request)
        {
            var result = await _invoiceTypeService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _invoiceTypeService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _invoiceTypeService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _invoiceTypeService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}