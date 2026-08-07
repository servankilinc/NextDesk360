using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.User;
using ExpressDesk360.Model.Dtos.User.Queries;
using ExpressDesk360.Model.Dtos.UserModule.User.Commands;
using ExpressDesk360.Business.Abstract.CompanyModule;
using ExpressDesk360.Business.Abstract.UserModule;

namespace ExpressDesk360.WebUI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        public UserController(ILogger<UserController> logger, IUserService userService, ICompanyService companyService) : base(logger)
        {
            _userService = userService;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyIds = await _companyService.SelectListAsync();
            var viewModel = new UserViewModel
            {
                CompanyIds = companyIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyIds = await _companyService.SelectListAsync();
            var viewModel = new UserCreateViewModel
            {
                CompanyIds = companyIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto createModel)
        {
            var result = await _userService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _userService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var companyIds = await _companyService.SelectListAsync();
            var viewModel = new UserUpdateViewModel
            {
                UpdateModel = result.Data,
                CompanyIds = companyIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto updateModel)
        {
            var result = await _userService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _userService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _userService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}