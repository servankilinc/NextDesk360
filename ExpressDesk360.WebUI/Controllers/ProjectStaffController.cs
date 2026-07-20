using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectStaff;
using ExpressDesk360.Model.Dtos.ProjectStaff.Commands;
using ExpressDesk360.Model.Dtos.ProjectStaff.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ProjectStaffController : BaseController
    {
        private readonly IProjectStaffService _projectStaffService;
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        public ProjectStaffController(ILogger<ProjectStaffController> logger, IProjectStaffService projectStaffService, IProjectService projectService, IUserService userService) : base(logger)
        {
            _projectStaffService = projectStaffService;
            _projectService = projectService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projectIds = await _projectService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new ProjectStaffViewModel
            {
                ProjectIds = projectIds.Data,
                UserIds = userIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var projectIds = await _projectService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new ProjectStaffCreateViewModel
            {
                ProjectIds = projectIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectStaffCreateDto createModel)
        {
            var result = await _projectStaffService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _projectStaffService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var projectIds = await _projectService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new ProjectStaffUpdateViewModel
            {
                UpdateModel = result.Data,
                ProjectIds = projectIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectStaffUpdateDto updateModel)
        {
            var result = await _projectStaffService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _projectStaffService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _projectStaffService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectStaffService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectStaffService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}