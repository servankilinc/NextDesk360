using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Shipping;
using ExpressDesk360.Model.Dtos.Shipping.Commands;
using ExpressDesk360.Model.Dtos.Shipping.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class ShippingController : BaseController
    {
        private readonly IShippingService _shippingService;
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IShippingTypeService _shippingTypeService;
        private readonly IUserService _userService;
        private readonly ICurrencyService _currencyService;
        public ShippingController(ILogger<ShippingController> logger, IShippingService shippingService, ICargoCompanyService cargoCompanyService, IShippingTypeService shippingTypeService, IUserService userService, ICurrencyService currencyService) : base(logger)
        {
            _shippingService = shippingService;
            _cargoCompanyService = cargoCompanyService;
            _shippingTypeService = shippingTypeService;
            _userService = userService;
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cargoCompanyIds = await _cargoCompanyService.SelectListAsync();
            var shippingTypeIds = await _shippingTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new ShippingViewModel
            {
                CargoCompanyIds = cargoCompanyIds.Data,
                ShippingTypeIds = shippingTypeIds.Data,
                UserIds = userIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cargoCompanyIds = await _cargoCompanyService.SelectListAsync();
            var shippingTypeIds = await _shippingTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var priceCurrencyIds = await _currencyService.SelectListAsync();
            var viewModel = new ShippingCreateViewModel
            {
                CargoCompanyIds = cargoCompanyIds.Data,
                ShippingTypeIds = shippingTypeIds.Data,
                UserIds = userIds.Data,
                PriceCurrencyIds = priceCurrencyIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShippingCreateDto request)
        {
            var result = await _shippingService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _shippingService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var cargoCompanyIds = await _cargoCompanyService.SelectListAsync();
            var shippingTypeIds = await _shippingTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var priceCurrencyIds = await _currencyService.SelectListAsync();
            var viewModel = new ShippingUpdateViewModel
            {
                UpdateModel = result.Data,
                CargoCompanyIds = cargoCompanyIds.Data,
                ShippingTypeIds = shippingTypeIds.Data,
                UserIds = userIds.Data,
                PriceCurrencyIds = priceCurrencyIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ShippingUpdateDto updateModel)
        {
            var result = await _shippingService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _shippingService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _shippingService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _shippingService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _shippingService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}