using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectFile;
using ExpressDesk360.Model.Dtos.ProjectFile.Commands;
using ExpressDesk360.Model.Dtos.ProjectFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ProjectFileController : BaseController
    {
        private readonly IProjectFileService _projectFileService;
        private readonly IProjectService _projectService;
        private readonly IFSFileService _fSFileService;
        public ProjectFileController(ILogger<ProjectFileController> logger, IProjectFileService projectFileService, IProjectService projectService, IFSFileService fSFileService) : base(logger)
        {
            _projectFileService = projectFileService;
            _projectService = projectService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projectIds = await _projectService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new ProjectFileViewModel
            {
                ProjectIds = projectIds.Data,
                FileIds = fileIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var projectIds = await _projectService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new ProjectFileCreateViewModel
            {
                ProjectIds = projectIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectFileCreateDto createModel)
        {
            var result = await _projectFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _projectFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var projectIds = await _projectService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new ProjectFileUpdateViewModel
            {
                UpdateModel = result.Data,
                ProjectIds = projectIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectFileUpdateDto updateModel)
        {
            var result = await _projectFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _projectFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _projectFileService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _projectFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _projectFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}