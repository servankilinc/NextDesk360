using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovementStockSerialMap.Queries
{
    public class StockMovementStockSerialMapDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public Guid StockMovementId { get; set; }
    }
}