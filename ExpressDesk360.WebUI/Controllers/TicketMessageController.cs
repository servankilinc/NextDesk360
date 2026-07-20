using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMessage;
using ExpressDesk360.Model.Dtos.TicketMessage.Commands;
using ExpressDesk360.Model.Dtos.TicketMessage.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketMessageController : BaseController
    {
        private readonly ITicketMessageService _ticketMessageService;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        public TicketMessageController(ILogger<TicketMessageController> logger, ITicketMessageService ticketMessageService, ITicketService ticketService, IUserService userService) : base(logger)
        {
            _ticketMessageService = ticketMessageService;
            _ticketService = ticketService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var senderIds = await _userService.SelectListAsync();
            var viewModel = new TicketMessageViewModel
            {
                TicketIds = ticketIds.Data,
                SenderIds = senderIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var senderIds = await _userService.SelectListAsync();
            var viewModel = new TicketMessageCreateViewModel
            {
                TicketIds = ticketIds.Data,
                SenderIds = senderIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMessageCreateDto createModel)
        {
            var result = await _ticketMessageService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketMessageService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketIds = await _ticketService.SelectListAsync();
            var senderIds = await _userService.SelectListAsync();
            var viewModel = new TicketMessageUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketIds = ticketIds.Data,
                SenderIds = senderIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketMessageUpdateDto updateModel)
        {
            var result = await _ticketMessageService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketMessageService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketMessageService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMessageService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMessageService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}