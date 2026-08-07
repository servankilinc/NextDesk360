using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.StockType.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockType.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class StockTypeController : BaseController
    {
        private readonly IStockTypeService _stockTypeService;
        public StockTypeController(ILogger<StockTypeController> logger, IStockTypeService stockTypeService) : base(logger)
        {
            _stockTypeService = stockTypeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _stockTypeService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _stockTypeService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _stockTypeService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _stockTypeService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockTypeCreateDto request)
        {
            var result = await _stockTypeService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _stockTypeService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StockTypeUpdateDto request)
        {
            var result = await _stockTypeService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _stockTypeService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
