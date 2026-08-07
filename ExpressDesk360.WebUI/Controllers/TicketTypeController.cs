using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketType;
using ExpressDesk360.Model.Dtos.TicketType.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.TicketType.Commands;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketTypeController : BaseController
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypeController(ILogger<TicketTypeController> logger, ITicketTypeService ticketTypeService) : base(logger)
        {
            _ticketTypeService = ticketTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new TicketTypeViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new TicketTypeCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketTypeCreateDto createModel)
        {
            var result = await _ticketTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _ticketTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new TicketTypeUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketTypeUpdateDto updateModel)
        {
            var result = await _ticketTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}