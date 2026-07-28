using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketStaff;
using ExpressDesk360.Model.Dtos.TicketStaff.Commands;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketStaffController : BaseController
    {
        private readonly ITicketStaffService _ticketStaffService;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        public TicketStaffController(ILogger<TicketStaffController> logger, ITicketStaffService ticketStaffService, ITicketService ticketService, IUserService userService) : base(logger)
        {
            _ticketStaffService = ticketStaffService;
            _ticketService = ticketService;
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var viewModel = new TicketStaffViewModel
            {
                TicketIds = ticketIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new TicketStaffCreateViewModel
            {
                TicketIds = ticketIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketStaffCreateDto createModel)
        {
            var result = await _ticketStaffService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketStaffService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketIds = await _ticketService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new TicketStaffUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketIds = ticketIds.Data,
                UserIds = userIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketStaffUpdateDto updateModel)
        {
            var result = await _ticketStaffService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketStaffService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketStaffService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketStaffService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketStaffService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}