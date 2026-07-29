using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels._TaskFile;

namespace ExpressDesk360.WebUI.Models.ViewModels._TaskFile
{
    public class _TaskFileViewModel
    {
        public SelectList? TaskIds { get; set; }
        public SelectList? FileIds { get; set; }
        public _TaskFileFilterModel FilterModel { get; set; } = new _TaskFileFilterModel();
    }

    public class _TaskFileFilterModel
    {
        public Guid TaskId { get; set; }
        public Guid FileId { get; set; }
    }
}