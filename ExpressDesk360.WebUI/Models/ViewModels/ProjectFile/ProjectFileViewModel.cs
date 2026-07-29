using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.ProjectFile;

namespace ExpressDesk360.WebUI.Models.ViewModels.ProjectFile
{
    public class ProjectFileViewModel
    {
        public SelectList? ProjectIds { get; set; }
        public SelectList? FileIds { get; set; }
        public ProjectFileFilterModel FilterModel { get; set; } = new ProjectFileFilterModel();
    }

    public class ProjectFileFilterModel
    {
        public Guid ProjectId { get; set; }
        public Guid FileId { get; set; }
}
}