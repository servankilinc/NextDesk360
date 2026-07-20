using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockGroupFaultTypeMap.Queries
{
    public class StockGroupFaultTypeMapDto : IDto
    {
        public Guid Id { get; set; }
        public int FaultTypeId { get; set; }
        public int StockGroupId { get; set; }
    }
}