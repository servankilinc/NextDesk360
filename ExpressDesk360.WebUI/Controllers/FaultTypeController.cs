using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.FaultType;
using ExpressDesk360.Model.Dtos.FaultType.Commands;
using ExpressDesk360.Model.Dtos.FaultType.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class FaultTypeController : BaseController
    {
        private readonly IFaultTypeService _faultTypeService;
        public FaultTypeController(ILogger<FaultTypeController> logger, IFaultTypeService faultTypeService) : base(logger)
        {
            _faultTypeService = faultTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new FaultTypeViewModel
            {
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new FaultTypeCreateViewModel
            {
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaultTypeCreateDto createModel)
        {
            var result = await _faultTypeService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _faultTypeService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var viewModel = new FaultTypeUpdateViewModel
            {
                UpdateModel = result.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FaultTypeUpdateDto updateModel)
        {
            var result = await _faultTypeService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _faultTypeService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _faultTypeService.DatatableServerSideAsync(request);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _faultTypeService.GetDetailAsync(id);
            if (!result.IsSuccess) return ToAction(result);

            var viewModel = new FaultTypeDetailViewModel
            {
                FaultType = result.Data
            };
            return View(viewModel);
        }
    }
}