using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.TicketMovementType.Commands;
using ExpressDesk360.Model.Dtos.TicketMovementType.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class TicketMovementTypeController : BaseController
    {
        private readonly ITicketMovementTypeService _ticketMovementTypeService;
        public TicketMovementTypeController(ILogger<TicketMovementTypeController> logger, ITicketMovementTypeService ticketMovementTypeService) : base(logger)
        {
            _ticketMovementTypeService = ticketMovementTypeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _ticketMovementTypeService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _ticketMovementTypeService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _ticketMovementTypeService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _ticketMovementTypeService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMovementTypeCreateDto request)
        {
            var result = await _ticketMovementTypeService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _ticketMovementTypeService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketMovementTypeUpdateDto request)
        {
            var result = await _ticketMovementTypeService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketMovementTypeService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _ticketMovementTypeService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _ticketMovementTypeService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}