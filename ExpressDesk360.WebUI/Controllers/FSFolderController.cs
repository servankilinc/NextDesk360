using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.FSFolder;
using ExpressDesk360.Model.Dtos.FSFolder.Commands;
using ExpressDesk360.Model.Dtos.FSFolder.Queries;

namespace ExpressDesk360.WebUI.Controllers
{
    public class FSFolderController : BaseController
    {
        private readonly IFSFolderService _fSFolderService;
        private readonly IUserService _userService;
        public FSFolderController(ILogger<FSFolderController> logger, IFSFolderService fSFolderService, IUserService userService) : base(logger)
        {
            _fSFolderService = fSFolderService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ownerIds = await _userService.SelectListAsync();
            var parentFolderIds = await _fSFolderService.SelectListAsync();
            var viewModel = new FSFolderViewModel
            {
                OwnerIds = ownerIds.Data,
                ParentFolderIds = parentFolderIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var ownerIds = await _userService.SelectListAsync();
            var parentFolderIds = await _fSFolderService.SelectListAsync();
            var viewModel = new FSFolderCreateViewModel
            {
                OwnerIds = ownerIds.Data,
                ParentFolderIds = parentFolderIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FSFolderCreateDto createModel)
        {
            var result = await _fSFolderService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _fSFolderService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var ownerIds = await _userService.SelectListAsync();
            var parentFolderIds = await _fSFolderService.SelectListAsync();
            var viewModel = new FSFolderUpdateViewModel
            {
                UpdateModel = result.Data,
                OwnerIds = ownerIds.Data,
                ParentFolderIds = parentFolderIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FSFolderUpdateDto updateModel)
        {
            var result = await _fSFolderService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _fSFolderService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            var result = await _fSFolderService.RestoreAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _fSFolderService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _fSFolderService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}