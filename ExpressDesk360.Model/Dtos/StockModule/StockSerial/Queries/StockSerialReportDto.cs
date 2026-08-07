using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockSerial.Queries
{
    public class StockSerialReportDto : IDto
    {
        public Guid Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? StockModelName { get; set; }
        public string? CompanyName { get; set; }
        public string? WarehouseName { get; set; }
        public bool IsAttachedToProduct { get; set; }
        public string? AttachedProductName { get; set; }
        public string WarrantyStatus { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime? CreateDateUtc { get; set; }
    }
}
