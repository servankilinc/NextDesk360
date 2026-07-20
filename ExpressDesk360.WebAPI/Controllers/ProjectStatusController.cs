using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.ProjectStatus.Commands;
using ExpressDesk360.Model.Dtos.ProjectStatus.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class ProjectStatusController : BaseController
    {
        private readonly IProjectStatusService _projectStatusService;
        public ProjectStatusController(ILogger<ProjectStatusController> logger, IProjectStatusService projectStatusService) : base(logger)
        {
            _projectStatusService = projectStatusService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projectStatusService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _projectStatusService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _projectStatusService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _projectStatusService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectStatusCreateDto request)
        {
            var result = await _projectStatusService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _projectStatusService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProjectStatusUpdateDto request)
        {
            var result = await _projectStatusService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectStatusService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _projectStatusService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _projectStatusService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectStatusService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectStatusService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}