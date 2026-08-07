using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskMovement;
using ExpressDesk360.Model.Dtos._TaskMovement.Queries;
using ExpressDesk360.Business.Abstract.TaskModule;
using ExpressDesk360.Business.Abstract.UserModule;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovement.Commands;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskMovementController : BaseController
    {
        private readonly ITaskMovementService __TaskMovementService;
        private readonly ITaskService __TaskService;
        private readonly ITaskMovementTypeService __TaskMovementTypeService;
        private readonly IUserService _userService;
        public _TaskMovementController(ILogger<_TaskMovementController> logger, ITaskMovementService _TaskMovementService, ITaskService _TaskService, ITaskMovementTypeService _TaskMovementTypeService, IUserService userService) : base(logger)
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
        public async Task<IActionResult> Create(TaskMovementCreateDto createModel)
        {
            var result = await __TaskMovementService.CreateAsync(createModel);
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
