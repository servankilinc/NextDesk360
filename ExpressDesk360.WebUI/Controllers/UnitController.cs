using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.Unit;
using ExpressDesk360.Model.Dtos.Unit.Commands;
using ExpressDesk360.Model.Dtos.Unit.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class UnitController : BaseController
    {
        private readonly IUnitService _unitService;
        public UnitController(ILogger<UnitController> logger, IUnitService unitService) : base(logger)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new UnitViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new UnitCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UnitCreateDto createModel)
        {
            var result = await _unitService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _unitService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new UnitUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UnitUpdateDto updateModel)
        {
            var result = await _unitService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _unitService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _unitService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}