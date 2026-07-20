using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels._TaskStatus;
using ExpressDesk360.Model.Dtos._TaskStatus.Commands;
using ExpressDesk360.Model.Dtos._TaskStatus.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class _TaskStatusController : BaseController
    {
        private readonly I_TaskStatusService __TaskStatusService;
        public _TaskStatusController(ILogger<_TaskStatusController> logger, I_TaskStatusService _TaskStatusService) : base(logger)
        {
            __TaskStatusService = _TaskStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new _TaskStatusViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new _TaskStatusCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskStatusCreateDto request)
        {
            var result = await __TaskStatusService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await __TaskStatusService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new _TaskStatusUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskStatusUpdateDto updateModel)
        {
            var result = await __TaskStatusService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await __TaskStatusService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await __TaskStatusService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await __TaskStatusService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await __TaskStatusService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}