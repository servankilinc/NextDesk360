using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.WebUI.Models.ViewModels.StockMovement;

namespace ExpressDesk360.WebUI.Models.ViewModels.StockMovement
{
    public class StockMovementViewModel
    {
        public SelectList? StockIds { get; set; }
        public SelectList? StockMovementTypeIds { get; set; }
        public SelectList? UserIds { get; set; }
        public StockMovementFilterModel FilterModel { get; set; } = new StockMovementFilterModel();
    }

    public class StockMovementFilterModel
    {
        public Guid StockId { get; set; }
        public int StockMovementTypeId { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}