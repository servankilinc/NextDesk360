using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.InvoiceType;
using ExpressDesk360.Model.Dtos.InvoiceType.Commands;
using ExpressDesk360.Model.Dtos.InvoiceType.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class InvoiceTypeController : BaseController
    {
        private readonly IInvoiceTypeService _invoiceTypeService;
        public InvoiceTypeController(ILogger<InvoiceTypeController> logger, IInvoiceTypeService invoiceTypeService) : base(logger)
        {
            _invoiceTypeService = invoiceTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new InvoiceTypeViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new InvoiceTypeCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceTypeCreateDto createModel)
        {
            var result = await _invoiceTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _invoiceTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new InvoiceTypeUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(InvoiceTypeUpdateDto updateModel)
        {
            var result = await _invoiceTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _invoiceTypeService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _invoiceTypeService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}