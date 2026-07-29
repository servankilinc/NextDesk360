using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketStatus;
using ExpressDesk360.Model.Dtos.TicketStatus.Commands;
using ExpressDesk360.Model.Dtos.TicketStatus.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketStatusController : BaseController
    {
        private readonly ITicketStatusService _ticketStatusService;
        public TicketStatusController(ILogger<TicketStatusController> logger, ITicketStatusService ticketStatusService) : base(logger)
        {
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new TicketStatusViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new TicketStatusCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketStatusCreateDto createModel)
        {
            var result = await _ticketStatusService.CreateAsync(createModel);
            return ToAction(result);
        }





        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketStatusService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketStatusService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
