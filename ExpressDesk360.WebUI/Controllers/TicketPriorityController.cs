using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketPriority;
using ExpressDesk360.Model.Dtos.TicketPriority.Commands;
using ExpressDesk360.Model.Dtos.TicketPriority.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketPriorityController : BaseController
    {
        private readonly ITicketPriorityService _ticketPriorityService;
        public TicketPriorityController(ILogger<TicketPriorityController> logger, ITicketPriorityService ticketPriorityService) : base(logger)
        {
            _ticketPriorityService = ticketPriorityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new TicketPriorityViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new TicketPriorityCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketPriorityCreateDto createModel)
        {
            var result = await _ticketPriorityService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _ticketPriorityService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new TicketPriorityUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketPriorityUpdateDto updateModel)
        {
            var result = await _ticketPriorityService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketPriorityService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _ticketPriorityService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketPriorityService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketPriorityService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}