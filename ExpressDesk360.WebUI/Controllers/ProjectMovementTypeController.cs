using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectMovementType;
using ExpressDesk360.Model.Dtos.ProjectMovementType.Commands;
using ExpressDesk360.Model.Dtos.ProjectMovementType.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ProjectMovementTypeController : BaseController
    {
        private readonly IProjectMovementTypeService _projectMovementTypeService;
        private readonly IProjectStatusService _projectStatusService;
        public ProjectMovementTypeController(ILogger<ProjectMovementTypeController> logger, IProjectMovementTypeService projectMovementTypeService, IProjectStatusService projectStatusService) : base(logger)
        {
            _projectMovementTypeService = projectMovementTypeService;
            _projectStatusService = projectStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projectStatusIds = await _projectStatusService.SelectListAsync();
            var viewModel = new ProjectMovementTypeViewModel
            {
                ProjectStatusIds = projectStatusIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var projectStatusIds = await _projectStatusService.SelectListAsync();
            var viewModel = new ProjectMovementTypeCreateViewModel
            {
                ProjectStatusIds = projectStatusIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectMovementTypeCreateDto createModel)
        {
            var result = await _projectMovementTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _projectMovementTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var projectStatusIds = await _projectStatusService.SelectListAsync();
            var viewModel = new ProjectMovementTypeUpdateViewModel
            {
                UpdateModel = result.Data,
                ProjectStatusIds = projectStatusIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectMovementTypeUpdateDto updateModel)
        {
            var result = await _projectMovementTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectMovementTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectMovementTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}