using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.StockBrand.Queries;
using ExpressDesk360.Model.Dtos.StockModule.StockBrand.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class StockBrandController : BaseController
    {
        private readonly IStockBrandService _stockBrandService;
        public StockBrandController(ILogger<StockBrandController> logger, IStockBrandService stockBrandService) : base(logger)
        {
            _stockBrandService = stockBrandService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _stockBrandService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _stockBrandService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _stockBrandService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _stockBrandService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockBrandCreateDto request)
        {
            var result = await _stockBrandService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _stockBrandService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StockBrandUpdateDto request)
        {
            var result = await _stockBrandService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _stockBrandService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _stockBrandService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _stockBrandService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
