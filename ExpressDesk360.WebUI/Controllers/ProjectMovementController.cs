using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectMovement;
using ExpressDesk360.Model.Dtos.ProjectMovement.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.ProjectMovement.Commands;
using ExpressDesk360.Business.Abstract.ProjectModule;
using ExpressDesk360.Business.Abstract.UserModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ProjectMovementController : BaseController
    {
        private readonly IProjectMovementService _projectMovementService;
        private readonly IProjectService _projectService;
        private readonly IProjectMovementTypeService _projectMovementTypeService;
        private readonly IUserService _userService;
        public ProjectMovementController(ILogger<ProjectMovementController> logger, IProjectMovementService projectMovementService, IProjectService projectService, IProjectMovementTypeService projectMovementTypeService, IUserService userService) : base(logger)
        {
            _projectMovementService = projectMovementService;
            _projectService = projectService;
            _projectMovementTypeService = projectMovementTypeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projectIds = await _projectService.SelectListAsync();
            var viewModel = new ProjectMovementViewModel
            {
                ProjectIds = projectIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var projectIds = await _projectService.SelectListAsync();
            var projectMovementTypeIds = await _projectMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new ProjectMovementCreateViewModel
            {
                ProjectIds = projectIds.Data,
                ProjectMovementTypeIds = projectMovementTypeIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectMovementCreateDto createModel)
        {
            var result = await _projectMovementService.CreateAsync(createModel);
            return ToAction(result);
        }





        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
