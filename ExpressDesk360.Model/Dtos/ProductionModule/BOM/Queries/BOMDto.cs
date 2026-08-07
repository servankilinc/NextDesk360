using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.ProductionModule.BOM.Queries
{
    public class BOMDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string? VersionName { get; set; }
        public bool Status { get; set; }
    }
}