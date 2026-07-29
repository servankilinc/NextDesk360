using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Currency;
using ExpressDesk360.Model.Dtos.Currency.Commands;
using ExpressDesk360.Model.Dtos.Currency.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService) : base(logger)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new CurrencyViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CurrencyCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CurrencyCreateDto createModel)
        {
            var result = await _currencyService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _currencyService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new CurrencyUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CurrencyUpdateDto updateModel)
        {
            var result = await _currencyService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _currencyService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _currencyService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}