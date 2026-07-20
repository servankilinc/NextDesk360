using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskMovementType;
using ExpressDesk360.Model.Dtos._TaskMovementType.Commands;
using ExpressDesk360.Model.Dtos._TaskMovementType.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskMovementTypeController : BaseController
    {
        private readonly I_TaskMovementTypeService __TaskMovementTypeService;
        private readonly I_TaskStatusService __TaskStatusService;
        public _TaskMovementTypeController(ILogger<_TaskMovementTypeController> logger, I_TaskMovementTypeService _TaskMovementTypeService, I_TaskStatusService _TaskStatusService) : base(logger)
        {
            __TaskMovementTypeService = _TaskMovementTypeService;
            __TaskStatusService = _TaskStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taskStatusIds = await __TaskStatusService.SelectListAsync();
            var viewModel = new _TaskMovementTypeViewModel
            {
                TaskStatusIds = taskStatusIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskStatusIds = await __TaskStatusService.SelectListAsync();
            var viewModel = new _TaskMovementTypeCreateViewModel
            {
                TaskStatusIds = taskStatusIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskMovementTypeCreateDto createModel)
        {
            var result = await __TaskMovementTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await __TaskMovementTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var taskStatusIds = await __TaskStatusService.SelectListAsync();
            var viewModel = new _TaskMovementTypeUpdateViewModel
            {
                UpdateModel = result.Data,
                TaskStatusIds = taskStatusIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskMovementTypeUpdateDto updateModel)
        {
            var result = await __TaskMovementTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await __TaskMovementTypeService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await __TaskMovementTypeService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}