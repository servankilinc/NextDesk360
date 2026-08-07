using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.StockMovement;
using ExpressDesk360.Model.Dtos.StockMovement.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockMovement.Commands;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Business.Abstract.InvoiceModule;
using ExpressDesk360.Business.Abstract.TicketModule;
using ExpressDesk360.Business.Abstract.UserModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class StockMovementController : BaseController
    {
        private readonly IStockMovementService _stockMovementService;
        private readonly IStockService _stockService;
        private readonly IStockMovementTypeService _stockMovementTypeService;
        private readonly IUserService _userService;
        private readonly IInvoiceService _invoiceService;
        private readonly ITicketMovementService _ticketMovementService;
        private readonly IWarehouseService _warehouseService;
        public StockMovementController(ILogger<StockMovementController> logger, IStockMovementService stockMovementService, IStockService stockService, IStockMovementTypeService stockMovementTypeService, IUserService userService, IInvoiceService invoiceService, ITicketMovementService ticketMovementService, IWarehouseService warehouseService) : base(logger)
        {
            _stockMovementService = stockMovementService;
            _stockService = stockService;
            _stockMovementTypeService = stockMovementTypeService;
            _userService = userService;
            _invoiceService = invoiceService;
            _ticketMovementService = ticketMovementService;
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockIds = await _stockService.SelectListAsync();
            var stockMovementTypeIds = await _stockMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var viewModel = new StockMovementViewModel
            {
                StockIds = stockIds.Data,
                StockMovementTypeIds = stockMovementTypeIds.Data,
                UserIds = userIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var stockIds = await _stockService.SelectListAsync();
            var stockMovementTypeIds = await _stockMovementTypeService.SelectListAsync();
            var userIds = await _userService.SelectListAsync();
            var invoiceIds = await _invoiceService.SelectListAsync();
            var ticketMovementIds = await _ticketMovementService.SelectListAsync();
            var warehouseIds = await _warehouseService.SelectListAsync();
            var viewModel = new StockMovementCreateViewModel
            {
                StockIds = stockIds.Data,
                StockMovementTypeIds = stockMovementTypeIds.Data,
                UserIds = userIds.Data,
                InvoiceIds = invoiceIds.Data,
                TicketMovementIds = ticketMovementIds.Data,
                WarehouseIds = warehouseIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockMovementCreateDto createModel)
        {
            var result = await _stockMovementService.CreateAsync(createModel);
            return ToAction(result);
        }





        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
