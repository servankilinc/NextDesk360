using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.Invoice.Queries;
using ExpressDesk360.Model.Dtos.InvoiceModule.Invoice.Commands;
using ExpressDesk360.Business.Abstract.InvoiceModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService) : base(logger)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _invoiceService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _invoiceService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _invoiceService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _invoiceService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreateDto request)
        {
            var result = await _invoiceService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _invoiceService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(InvoiceUpdateDto request)
        {
            var result = await _invoiceService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _invoiceService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _invoiceService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _invoiceService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}