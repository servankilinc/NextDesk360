using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Invoice;
using ExpressDesk360.Model.Dtos.Invoice.Commands;
using ExpressDesk360.Model.Dtos.Invoice.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceTypeService _invoiceTypeService;
        private readonly ICompanyService _companyService;
        private readonly ICurrencyService _currencyService;
        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceService invoiceService, IInvoiceTypeService invoiceTypeService, ICompanyService companyService, ICurrencyService currencyService) : base(logger)
        {
            _invoiceService = invoiceService;
            _invoiceTypeService = invoiceTypeService;
            _companyService = companyService;
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var invoiceTypeIds = await _invoiceTypeService.SelectListAsync();
            var sellerCompanyIds = await _companyService.SelectListAsync();
            var buyerCompanyIds = await _companyService.SelectListAsync();
            var viewModel = new InvoiceViewModel
            {
                InvoiceTypeIds = invoiceTypeIds.Data,
                SellerCompanyIds = sellerCompanyIds.Data,
                BuyerCompanyIds = buyerCompanyIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var invoiceTypeIds = await _invoiceTypeService.SelectListAsync();
            var sellerCompanyIds = await _companyService.SelectListAsync();
            var buyerCompanyIds = await _companyService.SelectListAsync();
            var currencyIds = await _currencyService.SelectListAsync();
            var viewModel = new InvoiceCreateViewModel
            {
                InvoiceTypeIds = invoiceTypeIds.Data,
                SellerCompanyIds = sellerCompanyIds.Data,
                BuyerCompanyIds = buyerCompanyIds.Data,
                CurrencyIds = currencyIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreateDto request)
        {
            var result = await _invoiceService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _invoiceService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var invoiceTypeIds = await _invoiceTypeService.SelectListAsync();
            var sellerCompanyIds = await _companyService.SelectListAsync();
            var buyerCompanyIds = await _companyService.SelectListAsync();
            var currencyIds = await _currencyService.SelectListAsync();
            var viewModel = new InvoiceUpdateViewModel
            {
                UpdateModel = result.Data,
                InvoiceTypeIds = invoiceTypeIds.Data,
                SellerCompanyIds = sellerCompanyIds.Data,
                BuyerCompanyIds = buyerCompanyIds.Data,
                CurrencyIds = currencyIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(InvoiceUpdateDto updateModel)
        {
            var result = await _invoiceService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _invoiceService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _invoiceService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _invoiceService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}