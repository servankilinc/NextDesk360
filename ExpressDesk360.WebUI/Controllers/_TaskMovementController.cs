using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskMovement;
using ExpressDesk360.Model.Dtos._TaskMovement.Commands;
using ExpressDesk360.Model.Dtos._TaskMovement.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskMovementController : BaseController
    {
        private readonly I_TaskMovementService __TaskMovementService;
        private readonly I_TaskService __TaskService;
        private readonly I_TaskMovementTypeService __TaskMovementTypeService;
        private readonly IUserService _userService;
        public _TaskMovementController(ILogger<_TaskMovementController> logger, I_TaskMovementService _TaskMovementService, I_TaskService _TaskService, I_TaskMovementTypeService _TaskMovementTypeService, IUserService userService) : base(logger)
        {
            __TaskMovementService = _TaskMovementService;
            __TaskService = _TaskService;
            __TaskMovementTypeService = _TaskMovementTypeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taskIds = await __TaskService.SelectListAsync();
            var taskMovementTypeIds = await __TaskMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new _TaskMovementViewModel
            {
                TaskIds = taskIds.Data,
                TaskMovementTypeIds = taskMovementTypeIds.Data,
                UserIds = userIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskIds = await __TaskService.SelectListAsync();
            var taskMovementTypeIds = await __TaskMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new _TaskMovementCreateViewModel
            {
                TaskIds = taskIds.Data,
                TaskMovementTypeIds = taskMovementTypeIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskMovementCreateDto request)
        {
            var result = await __TaskMovementService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await __TaskMovementService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var taskIds = await __TaskService.SelectListAsync();
            var taskMovementTypeIds = await __TaskMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new _TaskMovementUpdateViewModel
            {
                UpdateModel = result.Data,
                TaskIds = taskIds.Data,
                TaskMovementTypeIds = taskMovementTypeIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskMovementUpdateDto updateModel)
        {
            var result = await __TaskMovementService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await __TaskMovementService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await __TaskMovementService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}