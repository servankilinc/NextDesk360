using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos._Task.Queries;
using ExpressDesk360.Business.Abstract.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.Task.Commands;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class _TaskController : BaseController
    {
        private readonly ITaskService __TaskService;
        public _TaskController(ILogger<_TaskController> logger, ITaskService _TaskService) : base(logger)
        {
            __TaskService = _TaskService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await __TaskService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await __TaskService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await __TaskService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await __TaskService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDto request)
        {
            var result = await __TaskService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await __TaskService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskUpdateDto request)
        {
            var result = await __TaskService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await __TaskService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/restore")]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await __TaskService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await __TaskService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}