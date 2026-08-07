using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Ticket;
using ExpressDesk360.Model.Dtos.Ticket.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.Ticket.Commands;
using ExpressDesk360.Business.Abstract.ProductionModule;
using ExpressDesk360.Business.Abstract.CompanyModule;
using ExpressDesk360.Business.Abstract.TicketModule;
using ExpressDesk360.Business.Abstract.UserModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;
        private readonly ITicketTypeService _ticketTypeService;
        private readonly ITicketPriorityService _ticketPriorityService;
        private readonly ICompanyService _companyService;
        private readonly ICompanyProductService _companyProductService;
        private readonly ITicketMovementTypeService _ticketMovementTypeService;
        private readonly IUserService _userService;
        public TicketController(ILogger<TicketController> logger, ITicketService ticketService, ITicketTypeService ticketTypeService, ITicketPriorityService ticketPriorityService, ICompanyService companyService, ICompanyProductService companyProductService, ITicketMovementTypeService ticketMovementTypeService, IUserService userService) : base(logger)
        {
            _ticketService = ticketService;
            _ticketTypeService = ticketTypeService;
            _ticketPriorityService = ticketPriorityService;
            _companyService = companyService;
            _companyProductService = companyProductService;
            _ticketMovementTypeService = ticketMovementTypeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketTypeIds = await _ticketTypeService.SelectListAsync();
            var ticketPriorityIds = await _ticketPriorityService.SelectListAsync();
            var companyIds = await _companyService.SelectListAsync();
            var companyProductIds = await _companyProductService.SelectListAsync();
            var lastTicketMovementTypeIds = await _ticketMovementTypeService.SelectListAsync();
            var viewModel = new TicketViewModel
            {
                TicketTypeIds = ticketTypeIds.Data,
                TicketPriorityIds = ticketPriorityIds.Data,
                CompanyIds = companyIds.Data,
                CompanyProductIds = companyProductIds.Data,
                LastTicketMovementTypeIds = lastTicketMovementTypeIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketTypeIds = await _ticketTypeService.SelectListAsync();
            var ticketPriorityIds = await _ticketPriorityService.SelectListAsync();
            var requesterIds = await _userService.SelectListAsync();
            var companyIds = await _companyService.SelectListAsync();
            var companyProductIds = await _companyProductService.SelectListAsync();
            var lastTicketMovementTypeIds = await _ticketMovementTypeService.SelectListAsync();
            var viewModel = new TicketCreateViewModel
            {
                TicketTypeIds = ticketTypeIds.Data,
                TicketPriorityIds = ticketPriorityIds.Data,
                RequesterIds = requesterIds.Data,
                CompanyIds = companyIds.Data,
                CompanyProductIds = companyProductIds.Data,
                LastTicketMovementTypeIds = lastTicketMovementTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateDto createModel)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userId, out var requesterId))
            {
                createModel.RequesterId = requesterId;
            }
            var result = await _ticketService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketTypeIds = await _ticketTypeService.SelectListAsync();
            var ticketPriorityIds = await _ticketPriorityService.SelectListAsync();
            var requesterIds = await _userService.SelectListAsync();
            var companyIds = await _companyService.SelectListAsync();
            var companyProductIds = await _companyProductService.SelectListAsync();
            var lastTicketMovementTypeIds = await _ticketMovementTypeService.SelectListAsync();
            var viewModel = new TicketUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketTypeIds = ticketTypeIds.Data,
                TicketPriorityIds = ticketPriorityIds.Data,
                RequesterIds = requesterIds.Data,
                CompanyIds = companyIds.Data,
                CompanyProductIds = companyProductIds.Data,
                LastTicketMovementTypeIds = lastTicketMovementTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketUpdateDto updateModel)
        {
            var result = await _ticketService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}