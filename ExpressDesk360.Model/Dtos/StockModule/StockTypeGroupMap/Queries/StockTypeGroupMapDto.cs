using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockTypeGroupMap.Queries
{
    public class StockTypeGroupMapDto : IDto
    {
        public Guid Id { get; set; }
        public int StockTypeId { get; set; }
        public int StockGroupId { get; set; }
    }
}