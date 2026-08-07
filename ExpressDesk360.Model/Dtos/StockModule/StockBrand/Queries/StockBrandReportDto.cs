using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockBrand.Queries
{
    public class StockBrandReportDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
    }
}
