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

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _ticketStatusService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new TicketStatusUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketStatusUpdateDto updateModel)
        {
            var result = await _ticketStatusService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketStatusService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _ticketStatusService.RestoreAsync(id: id);
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