using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockGroupFaultTypeMap.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class StockGroupFaultTypeMapController : BaseController
    {
        private readonly IStockGroupFaultTypeMapService _stockGroupFaultTypeMapService;
        public StockGroupFaultTypeMapController(ILogger<StockGroupFaultTypeMapController> logger, IStockGroupFaultTypeMapService stockGroupFaultTypeMapService) : base(logger)
        {
            _stockGroupFaultTypeMapService = stockGroupFaultTypeMapService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _stockGroupFaultTypeMapService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/base")]
        public async Task<IActionResult> GetBase(Guid id)
        {
            var result = await _stockGroupFaultTypeMapService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _stockGroupFaultTypeMapService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _stockGroupFaultTypeMapService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockGroupFaultTypeMapCreateDto request)
        {
            var result = await _stockGroupFaultTypeMapService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:guid}/update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _stockGroupFaultTypeMapService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StockGroupFaultTypeMapUpdateDto request)
        {
            var result = await _stockGroupFaultTypeMapService.UpdateAsync(request);
            return ToAction(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _stockGroupFaultTypeMapService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _stockGroupFaultTypeMapService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupFaultTypeMapService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupFaultTypeMapService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}