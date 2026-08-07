using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMessageFile;
using ExpressDesk360.Model.Dtos.TicketMessageFile.Queries;
using ExpressDesk360.Model.Dtos.TicketModule.TicketMessageFile.Commands;
using ExpressDesk360.Business.Abstract.Common;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketMessageFileController : BaseController
    {
        private readonly ITicketMessageFileService _ticketMessageFileService;
        private readonly ITicketMessageService _ticketMessageService;
        private readonly IFSFileService _fSFileService;
        public TicketMessageFileController(ILogger<TicketMessageFileController> logger, ITicketMessageFileService ticketMessageFileService, ITicketMessageService ticketMessageService, IFSFileService fSFileService) : base(logger)
        {
            _ticketMessageFileService = ticketMessageFileService;
            _ticketMessageService = ticketMessageService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketMessageIds = await _ticketMessageService.SelectListAsync();
            var viewModel = new TicketMessageFileViewModel
            {
                TicketMessageIds = ticketMessageIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketMessageIds = await _ticketMessageService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new TicketMessageFileCreateViewModel
            {
                TicketMessageIds = ticketMessageIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMessageFileCreateDto createModel)
        {
            var result = await _ticketMessageFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketMessageFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketMessageIds = await _ticketMessageService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new TicketMessageFileUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketMessageIds = ticketMessageIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketMessageFileUpdateDto updateModel)
        {
            var result = await _ticketMessageFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketMessageFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMessageFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMessageFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}