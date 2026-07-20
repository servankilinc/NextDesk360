using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.BOMItem.Queries
{
    public class BOMItemDto : IDto
    {
        public Guid Id { get; set; }
        public Guid BOMId { get; set; }
        public Guid StockId { get; set; }
        public decimal Quantity { get; set; }
    }
}