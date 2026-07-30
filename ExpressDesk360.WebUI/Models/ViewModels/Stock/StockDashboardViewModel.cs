namespace ExpressDesk360.WebUI.Models.ViewModels.Stock
{
    public class StockDashboardViewModel
    {
        public int TotalStockModels { get; set; }
        public int TotalSerials { get; set; }
        public int TotalActiveWarranties { get; set; }
        public int AttachedSerials { get; set; }
        public List<RecentMovementViewModel>? RecentMovements { get; set; }
    }

    public class RecentMovementViewModel
    {
        public DateTime Date { get; set; }
        public string? StockModelName { get; set; }
        public string? MovementTypeName { get; set; }
        public decimal Quantity { get; set; }
    }
}
