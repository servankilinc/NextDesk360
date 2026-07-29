using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos._TaskMovement.Commands;
using ExpressDesk360.Model.Dtos._TaskMovement.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class _TaskMovementController : BaseController
    {
        private readonly I_TaskMovementService __TaskMovementService;
        public _TaskMovementController(ILogger<_TaskMovementController> logger, I_TaskMovementService _TaskMovementService) : base(logger)
        {
            __TaskMovementService = _TaskMovementService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await __TaskMovementService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await __TaskMovementService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await __TaskMovementService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await __TaskMovementService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskMovementCreateDto request)
        {
            var result = await __TaskMovementService.CreateAsync(request);
            return ToAction(result);
        }





        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await __TaskMovementService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
