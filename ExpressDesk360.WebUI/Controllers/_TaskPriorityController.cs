using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskPriority;
using ExpressDesk360.Model.Dtos._TaskPriority.Commands;
using ExpressDesk360.Model.Dtos._TaskPriority.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskPriorityController : BaseController
    {
        private readonly I_TaskPriorityService __TaskPriorityService;
        public _TaskPriorityController(ILogger<_TaskPriorityController> logger, I_TaskPriorityService _TaskPriorityService) : base(logger)
        {
            __TaskPriorityService = _TaskPriorityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new _TaskPriorityViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new _TaskPriorityCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskPriorityCreateDto request)
        {
            var result = await __TaskPriorityService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await __TaskPriorityService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new _TaskPriorityUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskPriorityUpdateDto updateModel)
        {
            var result = await __TaskPriorityService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await __TaskPriorityService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await __TaskPriorityService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskPriorityService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskPriorityService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}