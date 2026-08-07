using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovement.Queries
{
    public class StockMovementReportDto : IDto
    {
        public Guid Id { get; set; }
        public string? StockModelName { get; set; }
        public string? StockMovementTypeName { get; set; }
        public char InOutCode { get; set; }
        public string? UserName { get; set; }
        public decimal Quantity { get; set; }
        public string? WarehouseName { get; set; }
        public string? FaultTypeName { get; set; }
        public string? CompanyProductName { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CreateDateUtc { get; set; }
    }
}
