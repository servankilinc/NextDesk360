using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos._TaskMovementType.Commands;
using ExpressDesk360.Model.Dtos._TaskMovementType.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class _TaskMovementTypeController : BaseController
    {
        private readonly I_TaskMovementTypeService __TaskMovementTypeService;
        public _TaskMovementTypeController(ILogger<_TaskMovementTypeController> logger, I_TaskMovementTypeService _TaskMovementTypeService) : base(logger)
        {
            __TaskMovementTypeService = _TaskMovementTypeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await __TaskMovementTypeService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await __TaskMovementTypeService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await __TaskMovementTypeService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await __TaskMovementTypeService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskMovementTypeCreateDto request)
        {
            var result = await __TaskMovementTypeService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await __TaskMovementTypeService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskMovementTypeUpdateDto request)
        {
            var result = await __TaskMovementTypeService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await __TaskMovementTypeService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
