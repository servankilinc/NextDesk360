using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.TicketMovement.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMovement.Commands;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class TicketMovementController : BaseController
    {
        private readonly ITicketMovementService _ticketMovementService;
        public TicketMovementController(ILogger<TicketMovementController> logger, ITicketMovementService ticketMovementService) : base(logger)
        {
            _ticketMovementService = ticketMovementService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _ticketMovementService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _ticketMovementService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _ticketMovementService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _ticketMovementService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMovementCreateDto request)
        {
            var result = await _ticketMovementService.CreateAsync(request);
            return ToAction(result);
        }





        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _ticketMovementService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
