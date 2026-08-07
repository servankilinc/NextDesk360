using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.TicketStatus.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.TicketStatus.Commands;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class TicketStatusController : BaseController
    {
        private readonly ITicketStatusService _ticketStatusService;
        public TicketStatusController(ILogger<TicketStatusController> logger, ITicketStatusService ticketStatusService) : base(logger)
        {
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _ticketStatusService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _ticketStatusService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _ticketStatusService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _ticketStatusService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketStatusCreateDto request)
        {
            var result = await _ticketStatusService.CreateAsync(request);
            return ToAction(result);
        }





        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _ticketStatusService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketStatusService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketStatusService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
