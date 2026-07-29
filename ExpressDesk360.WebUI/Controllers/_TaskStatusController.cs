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
        public async Task<IActionResult> Create(TaskStatusCreateDto createModel)
        {
            var result = await __TaskStatusService.CreateAsync(createModel);
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
