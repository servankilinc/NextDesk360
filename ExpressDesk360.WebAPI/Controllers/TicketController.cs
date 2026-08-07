using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.Ticket.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Commands;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;
        public TicketController(ILogger<TicketController> logger, ITicketService ticketService) : base(logger)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _ticketService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _ticketService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _ticketService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _ticketService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateDto request)
        {
            var result = await _ticketService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketUpdateDto request)
        {
            var result = await _ticketService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _ticketService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}