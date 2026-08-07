using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.StockGroup.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockGroup.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class StockGroupController : BaseController
    {
        private readonly IStockGroupService _stockGroupService;
        public StockGroupController(ILogger<StockGroupController> logger, IStockGroupService stockGroupService) : base(logger)
        {
            _stockGroupService = stockGroupService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _stockGroupService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _stockGroupService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _stockGroupService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _stockGroupService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockGroupCreateDto request)
        {
            var result = await _stockGroupService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _stockGroupService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StockGroupUpdateDto request)
        {
            var result = await _stockGroupService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _stockGroupService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockGroupService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
