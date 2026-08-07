using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMovementType;
using ExpressDesk360.Model.Dtos.TicketMovementType.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMovementType.Commands;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketMovementTypeController : BaseController
    {
        private readonly ITicketMovementTypeService _ticketMovementTypeService;
        private readonly ITicketStatusService _ticketStatusService;
        public TicketMovementTypeController(ILogger<TicketMovementTypeController> logger, ITicketMovementTypeService ticketMovementTypeService, ITicketStatusService ticketStatusService) : base(logger)
        {
            _ticketMovementTypeService = ticketMovementTypeService;
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketStatusIds = await _ticketStatusService.SelectListAsync();
            var viewModel = new TicketMovementTypeViewModel
            {
                TicketStatusIds = ticketStatusIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketStatusIds = await _ticketStatusService.SelectListAsync();
            var viewModel = new TicketMovementTypeCreateViewModel
            {
                TicketStatusIds = ticketStatusIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMovementTypeCreateDto createModel)
        {
            var result = await _ticketMovementTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _ticketMovementTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketStatusIds = await _ticketStatusService.SelectListAsync();
            var viewModel = new TicketMovementTypeUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketStatusIds = ticketStatusIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketMovementTypeUpdateDto updateModel)
        {
            var result = await _ticketMovementTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}