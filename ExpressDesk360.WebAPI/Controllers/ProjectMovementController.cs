using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.ProjectMovement.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovement.Commands;
using ExpressDesk360.Business.Abstract.ProjectModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class ProjectMovementController : BaseController
    {
        private readonly IProjectMovementService _projectMovementService;
        public ProjectMovementController(ILogger<ProjectMovementController> logger, IProjectMovementService projectMovementService) : base(logger)
        {
            _projectMovementService = projectMovementService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _projectMovementService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _projectMovementService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _projectMovementService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _projectMovementService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectMovementCreateDto request)
        {
            var result = await _projectMovementService.CreateAsync(request);
            return ToAction(result);
        }





        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _projectMovementService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
