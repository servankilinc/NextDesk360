using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskFile;
using ExpressDesk360.Model.Dtos._TaskFile.Commands;
using ExpressDesk360.Model.Dtos._TaskFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskFileController : BaseController
    {
        private readonly I_TaskFileService __TaskFileService;
        private readonly I_TaskService __TaskService;
        private readonly IFSFileService _fSFileService;
        public _TaskFileController(ILogger<_TaskFileController> logger, I_TaskFileService _TaskFileService, I_TaskService _TaskService, IFSFileService fSFileService) : base(logger)
        {
            __TaskFileService = _TaskFileService;
            __TaskService = _TaskService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taskIds = await __TaskService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new _TaskFileViewModel
            {
                TaskIds = taskIds.Data,
                FileIds = fileIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskIds = await __TaskService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new _TaskFileCreateViewModel
            {
                TaskIds = taskIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFileCreateDto createModel)
        {
            var result = await __TaskFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await __TaskFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var taskIds = await __TaskService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new _TaskFileUpdateViewModel
            {
                UpdateModel = result.Data,
                TaskIds = taskIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskFileUpdateDto updateModel)
        {
            var result = await __TaskFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await __TaskFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await __TaskFileService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}