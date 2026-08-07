using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._Task;
using ExpressDesk360.Model.Dtos._Task.Queries;
using ExpressDesk360.Business.Abstract.TaskModule;
using ExpressDesk360.Business.Abstract.UserModule;
using ExpressDesk360.Model.Dtos.TaskModule.Task.Commands;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskController : BaseController
    {
        private readonly ITaskService __TaskService;
        private readonly ITaskPriorityService __TaskPriorityService;
        private readonly ITaskMovementTypeService __TaskMovementTypeService;
        private readonly IUserService _userService;
        public _TaskController(ILogger<_TaskController> logger, ITaskService _TaskService, ITaskPriorityService _TaskPriorityService, ITaskMovementTypeService _TaskMovementTypeService, IUserService userService) : base(logger)
        {
            __TaskService = _TaskService;
            __TaskPriorityService = _TaskPriorityService;
            __TaskMovementTypeService = _TaskMovementTypeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taskPriorityIds = await __TaskPriorityService.SelectListAsync();
            var lastTaskMovementTypeIds = await __TaskMovementTypeService.SelectListAsync();
            var viewModel = new _TaskViewModel
            {
                TaskPriorityIds = taskPriorityIds.Data,
                LastTaskMovementTypeIds = lastTaskMovementTypeIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskPriorityIds = await __TaskPriorityService.SelectListAsync();
            var ownerIds = await _userService.SelectListAsync();
            var lastTaskMovementTypeIds = await __TaskMovementTypeService.SelectListAsync();
            var viewModel = new _TaskCreateViewModel
            {
                TaskPriorityIds = taskPriorityIds.Data,
                OwnerIds = ownerIds.Data,
                LastTaskMovementTypeIds = lastTaskMovementTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDto createModel)
        {
            var result = await __TaskService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await __TaskService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var taskPriorityIds = await __TaskPriorityService.SelectListAsync();
            var ownerIds = await _userService.SelectListAsync();
            var lastTaskMovementTypeIds = await __TaskMovementTypeService.SelectListAsync();
            var viewModel = new _TaskUpdateViewModel
            {
                UpdateModel = result.Data,
                TaskPriorityIds = taskPriorityIds.Data,
                OwnerIds = ownerIds.Data,
                LastTaskMovementTypeIds = lastTaskMovementTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskUpdateDto updateModel)
        {
            var result = await __TaskService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await __TaskService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await __TaskService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}