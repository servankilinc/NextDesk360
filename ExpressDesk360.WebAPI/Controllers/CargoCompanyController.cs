using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebAPI.Controllers.Base;
using ExpressDesk360.Model.Dtos.CargoCompany.Commands;
using ExpressDesk360.Model.Dtos.CargoCompany.Queries;

namespace ExpressDesk360.WebAPI.Controllers
{
    public class CargoCompanyController : BaseController
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ILogger<CargoCompanyController> logger, ICargoCompanyService cargoCompanyService) : base(logger)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _cargoCompanyService.GetAsync(id: id);
            return ToAction(result);
        }

        [HttpGet("{id:int}/base")]
        public async Task<IActionResult> GetBase(int id)
        {
            var result = await _cargoCompanyService.GetBaseAsync(id: id);
            return ToAction(result);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetList(DynamicRequest? request = default)
        {
            var result = await _cargoCompanyService.GetListAsync(request);
            return ToAction(result);
        }

        [HttpPost("list/base")]
        public async Task<IActionResult> GetBaseList(DynamicRequest? request = default)
        {
            var result = await _cargoCompanyService.GetBaseListAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CargoCompanyCreateDto request)
        {
            var result = await _cargoCompanyService.CreateAsync(request);
            return ToAction(result);
        }

        [HttpGet("{id:int}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _cargoCompanyService.GetUpdateModelAsync(id: id);
            return ToAction(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CargoCompanyUpdateDto request)
        {
            var result = await _cargoCompanyService.UpdateAsync(request);
            return ToAction(result);
        }



        [HttpPost("pagination")]
        public async Task<IActionResult> Pagination(DynamicPaginationRequest request)
        {
            var result = await _cargoCompanyService.PaginationAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/client")]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _cargoCompanyService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost("datatable/server")]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _cargoCompanyService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}
