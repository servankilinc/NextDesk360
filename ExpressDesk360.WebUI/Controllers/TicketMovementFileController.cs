using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.TicketMovementFile;
using ExpressDesk360.Model.Dtos.TicketMovementFile.Commands;
using ExpressDesk360.Model.Dtos.TicketMovementFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class TicketMovementFileController : BaseController
    {
        private readonly ITicketMovementFileService _ticketMovementFileService;
        private readonly ITicketMovementService _ticketMovementService;
        private readonly IFSFileService _fSFileService;
        public TicketMovementFileController(ILogger<TicketMovementFileController> logger, ITicketMovementFileService ticketMovementFileService, ITicketMovementService ticketMovementService, IFSFileService fSFileService) : base(logger)
        {
            _ticketMovementFileService = ticketMovementFileService;
            _ticketMovementService = ticketMovementService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ticketMovementIds = await _ticketMovementService.SelectListAsync();
            var viewModel = new TicketMovementFileViewModel
            {
                TicketMovementIds = ticketMovementIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ticketMovementIds = await _ticketMovementService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new TicketMovementFileCreateViewModel
            {
                TicketMovementIds = ticketMovementIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketMovementFileCreateDto createModel)
        {
            var result = await _ticketMovementFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _ticketMovementFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ticketMovementIds = await _ticketMovementService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new TicketMovementFileUpdateViewModel
            {
                UpdateModel = result.Data,
                TicketMovementIds = ticketMovementIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TicketMovementFileUpdateDto updateModel)
        {
            var result = await _ticketMovementFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ticketMovementFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _ticketMovementFileService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _ticketMovementFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}