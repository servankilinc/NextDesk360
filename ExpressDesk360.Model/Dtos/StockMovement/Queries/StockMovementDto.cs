using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockMovement.Queries
{
    public class StockMovementDto : IDto
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public int StockMovementTypeId { get; set; }
        public Guid? UserId { get; set; }
        public decimal Quantity { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? TicketMovementId { get; set; }
        public int? WarehouseId { get; set; }
        public DateTime Date { get; set; }
    }
}