using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskStaff;
using ExpressDesk360.Model.Dtos._TaskStaff.Commands;
using ExpressDesk360.Model.Dtos._TaskStaff.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskStaffController : BaseController
    {
        private readonly I_TaskStaffService __TaskStaffService;
        private readonly I_TaskService __TaskService;
        private readonly IUserService _userService;
        public _TaskStaffController(ILogger<_TaskStaffController> logger, I_TaskStaffService _TaskStaffService, I_TaskService _TaskService, IUserService userService) : base(logger)
        {
            __TaskStaffService = _TaskStaffService;
            __TaskService = _TaskService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taskIds = await __TaskService.SelectListAsync();
            var viewModel = new _TaskStaffViewModel
            {
                TaskIds = taskIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var taskIds = await __TaskService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new _TaskStaffCreateViewModel
            {
                TaskIds = taskIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskStaffCreateDto request)
        {
            var result = await __TaskStaffService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await __TaskStaffService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var taskIds = await __TaskService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new _TaskStaffUpdateViewModel
            {
                UpdateModel = result.Data,
                TaskIds = taskIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskStaffUpdateDto updateModel)
        {
            var result = await __TaskStaffService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await __TaskStaffService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await __TaskStaffService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskStaffService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskStaffService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}