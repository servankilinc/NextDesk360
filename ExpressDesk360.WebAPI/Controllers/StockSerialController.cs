using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.StockSerial.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockSerial.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class StockSerialController : BaseController
    {
        private readonly IStockSerialService _stockSerialService;
        public StockSerialController(ILogger<StockSerialController> logger, IStockSerialService stockSerialService) : base(logger)
        {
            _stockSerialService = stockSerialService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _stockSerialService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _stockSerialService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _stockSerialService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _stockSerialService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockSerialCreateDto request)
        {
            var result = await _stockSerialService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockSerialService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StockSerialUpdateDto request)
        {
            var result = await _stockSerialService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _stockSerialService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockSerialService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockSerialService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
