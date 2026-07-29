using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketFile;
using ExpressDesk360.Model.Dtos.TicketFile.Commands;
using ExpressDesk360.Model.Dtos.TicketFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketFileController : BaseController
    {
        private readonly ITicketFileService _ticketFileService;
        private readonly ITicketService _ticketService;
        private readonly IFSFileService _fSFileService;
        public TicketFileController(ILogger<TicketFileController> logger, ITicketFileService ticketFileService, ITicketService ticketService, IFSFileService fSFileService) : base(logger)
        {
            _ticketFileService = ticketFileService;
            _ticketService = ticketService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var viewModel = new TicketFileViewModel
            {
                TicketIds = ticketIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketIds = await _ticketService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new TicketFileCreateViewModel
            {
                TicketIds = ticketIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketFileCreateDto createModel)
        {
            var result = await _ticketFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketIds = await _ticketService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new TicketFileUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketIds = ticketIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketFileUpdateDto updateModel)
        {
            var result = await _ticketFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}