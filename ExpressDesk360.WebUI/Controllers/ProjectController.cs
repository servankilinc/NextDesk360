using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Project;
using ExpressDesk360.Model.Dtos.Project.Queries;
using ExpressDesk360.Model.Dtos.ProjectModule.Project.Commands;
using ExpressDesk360.Business.Abstract.ProjectModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;
        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService) : base(logger)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ProjectViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProjectCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateDto createModel)
        {
            var result = await _projectService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _projectService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new ProjectUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateDto updateModel)
        {
            var result = await _projectService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _projectService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _projectService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}