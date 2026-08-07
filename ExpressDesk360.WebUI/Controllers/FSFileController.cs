using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.WebUI.Controllers.Base;
using ExpressDesk360.WebUI.Models.ViewModels.FSFile;
using ExpressDesk360.Model.Dtos.FSFile.Queries;
using ExpressDesk360.Model.Dtos.Common.FSFile.Commands;
using ExpressDesk360.Business.Abstract.Common;

namespace ExpressDesk360.WebUI.Controllers
{
    public class FSFileController : BaseController
    {
        private readonly IFSFileService _fSFileService;
        private readonly IFSFolderService _fSFolderService;
        public FSFileController(ILogger<FSFileController> logger, IFSFileService fSFileService, IFSFolderService fSFolderService) : base(logger)
        {
            _fSFileService = fSFileService;
            _fSFolderService = fSFolderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var folderIds = await _fSFolderService.SelectListAsync();
            var viewModel = new FSFileViewModel
            {
                FolderIds = folderIds.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var folderIds = await _fSFolderService.SelectListAsync();
            var viewModel = new FSFileCreateViewModel
            {
                FolderIds = folderIds.Data
            };
            return PartialView("./Partials/CreateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FSFileCreateDto createModel)
        {
            var result = await _fSFileService.CreateAsync(createModel);
            return ToAction(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _fSFileService.GetUpdateModelAsync(id: id); if  ( ! result . IsSuccess ) return  ToAction ( result ) ; 
            var folderIds = await _fSFolderService.SelectListAsync();
            var viewModel = new FSFileUpdateViewModel
            {
                UpdateModel = result.Data,
                FolderIds = folderIds.Data
            };
            return PartialView("./Partials/UpdateForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FSFileUpdateDto updateModel)
        {
            var result = await _fSFileService.UpdateAsync(updateModel);
            return ToAction(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _fSFileService.DeleteAsync(id: id);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableClientSide(DynamicDatatableRequest request)
        {
            var result = await _fSFileService.DatatableClientSideAsync(request);
            return ToAction(result);
        }

        [HttpPost]
        public async Task<IActionResult> DatatableServerSide(DynamicDatatableRequest request)
        {
            var result = await _fSFileService.DatatableServerSideAsync(request);
            return ToAction(result);
        }
    }
}