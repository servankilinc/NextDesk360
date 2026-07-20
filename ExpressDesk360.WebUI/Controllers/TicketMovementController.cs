using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMovement;
using ExpressDesk360.Model.Dtos.TicketMovement.Commands;
using ExpressDesk360.Model.Dtos.TicketMovement.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketMovementController : BaseController
    {
        private readonly ITicketMovementService _ticketMovementService;
        private readonly ITicketService _ticketService;
        private readonly ITicketMovementTypeService _ticketMovementTypeService;
        private readonly IUserService _userService;
        private readonly IShippingService _shippingService;
        private readonly IFaultTypeService _faultTypeService;
        public TicketMovementController(ILogger<TicketMovementController> logger, ITicketMovementService ticketMovementService, ITicketService ticketService, ITicketMovementTypeService ticketMovementTypeService, IUserService userService, IShippingService shippingService, IFaultTypeService faultTypeService) : base(logger)
        {
            _ticketMovementService = ticketMovementService;
            _ticketService = ticketService;
            _ticketMovementTypeService = ticketMovementTypeService;
            _userService = userService;
            _shippingService = shippingService;
            _faultTypeService = faultTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var viewModel = new TicketMovementViewModel
            {
                TicketIds = ticketIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var ticketMovementTypeIds = await _ticketMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var shippingIds = await _shippingService.SelectListAsync();
            var faultTypeIds = await _faultTypeService.SelectListAsync();
            var viewModel = new TicketMovementCreateViewModel
            {
                TicketIds = ticketIds.Data,
                TicketMovementTypeIds = ticketMovementTypeIds.Data,
                UserIds = userIds.Data,
                ShippingIds = shippingIds.Data,
                FaultTypeIds = faultTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMovementCreateDto createModel)
        {
            var result = await _ticketMovementService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketMovementService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketIds = await _ticketService.SelectListAsync();
            var ticketMovementTypeIds = await _ticketMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var shippingIds = await _shippingService.SelectListAsync();
            var faultTypeIds = await _faultTypeService.SelectListAsync();
            var viewModel = new TicketMovementUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketIds = ticketIds.Data,
                TicketMovementTypeIds = ticketMovementTypeIds.Data,
                UserIds = userIds.Data,
                ShippingIds = shippingIds.Data,
                FaultTypeIds = faultTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketMovementUpdateDto updateModel)
        {
            var result = await _ticketMovementService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketMovementService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketMovementService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}