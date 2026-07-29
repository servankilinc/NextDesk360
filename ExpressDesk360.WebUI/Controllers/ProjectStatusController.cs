using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectStatus;
using ExpressDesk360.Model.Dtos.ProjectStatus.Commands;
using ExpressDesk360.Model.Dtos.ProjectStatus.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ProjectStatusController : BaseController
    {
        private readonly IProjectStatusService _projectStatusService;
        public ProjectStatusController(ILogger<ProjectStatusController> logger, IProjectStatusService projectStatusService) : base(logger)
        {
            _projectStatusService = projectStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ProjectStatusViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProjectStatusCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectStatusCreateDto createModel)
        {
            var result = await _projectStatusService.CreateAsync(createModel);
            return ToAction(result);
        }





        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectStatusService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectStatusService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
