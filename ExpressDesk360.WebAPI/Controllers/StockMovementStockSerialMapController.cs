using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.StockMovementStockSerialMap.Commands;
using ExpressDesk360.Model.Dtos.StockMovementStockSerialMap.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class StockMovementStockSerialMapController : BaseController
    {
        private readonly IStockMovementStockSerialMapService _stockMovementStockSerialMapService;
        public StockMovementStockSerialMapController(ILogger<StockMovementStockSerialMapController> logger, IStockMovementStockSerialMapService stockMovementStockSerialMapService) : base(logger)
        {
            _stockMovementStockSerialMapService = stockMovementStockSerialMapService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _stockMovementStockSerialMapService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _stockMovementStockSerialMapService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockMovementStockSerialMapCreateDto request)
        {
            var result = await _stockMovementStockSerialMapService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StockMovementStockSerialMapUpdateDto request)
        {
            var result = await _stockMovementStockSerialMapService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockMovementStockSerialMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _stockMovementStockSerialMapService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementStockSerialMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockMovementStockSerialMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}