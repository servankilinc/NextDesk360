using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.UserFile;
using ExpressDesk360.Model.Dtos.UserFile.Commands;
using ExpressDesk360.Model.Dtos.UserFile.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class UserFileController : BaseController
    {
        private readonly IUserFileService _userFileService;
        private readonly IUserService _userService;
        private readonly IFSFileService _fSFileService;
        public UserFileController(ILogger<UserFileController> logger, IUserFileService userFileService, IUserService userService, IFSFileService fSFileService) : base(logger)
        {
            _userFileService = userFileService;
            _userService = userService;
            _fSFileService = fSFileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userIds = await _userService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new UserFileViewModel
            {
                UserIds = userIds.Data,
                FileIds = fileIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userIds = await _userService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new UserFileCreateViewModel
            {
                UserIds = userIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserFileCreateDto createModel)
        {
            var result = await _userFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _userFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var userIds = await _userService.SelectListAsync();
            var fileIds = await _fSFileService.SelectListAsync();
            var viewModel = new UserFileUpdateViewModel
            {
                UpdateModel = result.Data,
                UserIds = userIds.Data,
                FileIds = fileIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserFileUpdateDto updateModel)
        {
            var result = await _userFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _userFileService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _userFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _userFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}