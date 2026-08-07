using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.FaultType.Queries;
using ExpressDesk360.Model.Dtos.StockModule.FaultType.Commands;
using ExpressDesk360.Business.Abstract.StockModule;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class FaultTypeController : BaseController
    {
        private readonly IFaultTypeService _faultTypeService;
        public FaultTypeController(ILogger<FaultTypeController> logger, IFaultTypeService faultTypeService) : base(logger)
        {
            _faultTypeService = faultTypeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _faultTypeService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _faultTypeService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _faultTypeService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _faultTypeService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaultTypeCreateDto request)
        {
            var result = await _faultTypeService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _faultTypeService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FaultTypeUpdateDto request)
        {
            var result = await _faultTypeService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _faultTypeService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _faultTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _faultTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
