using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockGroupBrandMap.Queries
{
    public class StockGroupBrandMapDto : IDto
    {
        public Guid Id { get; set; }
        public int StockBrandId { get; set; }
        public int StockGroupId { get; set; }
    }
}