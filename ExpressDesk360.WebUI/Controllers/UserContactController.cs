using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.UserContact;
using ExpressDesk360.Model.Dtos.UserContact.Commands;
using ExpressDesk360.Model.Dtos.UserContact.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class UserContactController : BaseController
    {
        private readonly IUserContactService _userContactService;
        private readonly IUserService _userService;
        private readonly IContactTypeService _contactTypeService;
        public UserContactController(ILogger<UserContactController> logger, IUserContactService userContactService, IUserService userService, IContactTypeService contactTypeService) : base(logger)
        {
            _userContactService = userContactService;
            _userService = userService;
            _contactTypeService = contactTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userIds = await _userService.SelectListAsync();
            var contactTypeIds = await _contactTypeService.SelectListAsync();
            var viewModel = new UserContactViewModel
            {
                UserIds = userIds.Data,
                ContactTypeIds = contactTypeIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userIds = await _userService.SelectListAsync();
            var contactTypeIds = await _contactTypeService.SelectListAsync();
            var viewModel = new UserContactCreateViewModel
            {
                UserIds = userIds.Data,
                ContactTypeIds = contactTypeIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserContactCreateDto createModel)
        {
            var result = await _userContactService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _userContactService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var userIds = await _userService.SelectListAsync();
            var contactTypeIds = await _contactTypeService.SelectListAsync();
            var viewModel = new UserContactUpdateViewModel
            {
                UpdateModel = result.Data,
                UserIds = userIds.Data,
                ContactTypeIds = contactTypeIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserContactUpdateDto updateModel)
        {
            var result = await _userContactService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userContactService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _userContactService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _userContactService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _userContactService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}