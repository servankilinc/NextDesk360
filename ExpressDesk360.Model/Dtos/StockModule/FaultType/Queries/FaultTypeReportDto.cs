using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.FaultType.Queries
{
    public class FaultTypeReportDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
    }
}
