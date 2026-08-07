using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.Stock.Queries
{
    public class StockReportDto : IDto
    {
        public Guid Id { get; set; }
        public string? StockGroupName { get; set; }
        public string? StockBrandName { get; set; }
        public string? ModelName { get; set; }
        public string? ModelCode { get; set; }
        public string? ModelType { get; set; }
        public string? UnitShortName { get; set; }
        public bool SerialTracking { get; set; }
        public decimal Vat { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string? PurchaseCurrencyShortName { get; set; }
        public decimal? SalePrice { get; set; }
        public string? SalePriceCurrencyShortName { get; set; }
        public int TotalSerialCount { get; set; }
        public int AvailableSerialCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
    }
}
