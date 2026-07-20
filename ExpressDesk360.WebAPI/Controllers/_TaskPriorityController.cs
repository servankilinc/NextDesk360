using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos._TaskPriority.Commands;
using ExpressDesk360.Model.Dtos._TaskPriority.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class _TaskPriorityController : BaseController
    {
        private readonly I_TaskPriorityService __TaskPriorityService;
        public _TaskPriorityController(ILogger<_TaskPriorityController> logger, I_TaskPriorityService _TaskPriorityService) : base(logger)
        {
            __TaskPriorityService = _TaskPriorityService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await __TaskPriorityService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await __TaskPriorityService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await __TaskPriorityService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await __TaskPriorityService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskPriorityCreateDto request)
        {
            var result = await __TaskPriorityService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await __TaskPriorityService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskPriorityUpdateDto request)
        {
            var result = await __TaskPriorityService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await __TaskPriorityService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await __TaskPriorityService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await __TaskPriorityService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskPriorityService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskPriorityService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}