using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketServicePrice;
using ExpressDesk360.Model.Dtos.TicketServicePrice.Commands;
using ExpressDesk360.Model.Dtos.TicketServicePrice.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketServicePriceController : BaseController
    {
        private readonly ITicketServicePriceService _ticketServicePriceService;
        private readonly ITicketService _ticketService;
        private readonly ICurrencyService _currencyService;
        public TicketServicePriceController(ILogger<TicketServicePriceController> logger, ITicketServicePriceService ticketServicePriceService, ITicketService ticketService, ICurrencyService currencyService) : base(logger)
        {
            _ticketServicePriceService = ticketServicePriceService;
            _ticketService = ticketService;
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var viewModel = new TicketServicePriceViewModel
            {
                TicketIds = ticketIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var currencyIds = await _currencyService.SelectListAsync();
            var viewModel = new TicketServicePriceCreateViewModel
            {
                TicketIds = ticketIds.Data,
                CurrencyIds = currencyIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketServicePriceCreateDto createModel)
        {
            var result = await _ticketServicePriceService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketServicePriceService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketIds = await _ticketService.SelectListAsync();
            var currencyIds = await _currencyService.SelectListAsync();
            var viewModel = new TicketServicePriceUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketIds = ticketIds.Data,
                CurrencyIds = currencyIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketServicePriceUpdateDto updateModel)
        {
            var result = await _ticketServicePriceService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketServicePriceService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketServicePriceService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketServicePriceService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketServicePriceService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}