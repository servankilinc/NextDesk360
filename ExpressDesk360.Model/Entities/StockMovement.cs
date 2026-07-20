using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockMovement : IEntity, ISoftDeletableEntity, IAuditableEntity
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
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual Stock? Stock { get; set; }
        public virtual StockMovementType? StockMovementType { get; set; }
        public virtual User? User { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual TicketMovement? TicketMovement { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public virtual ICollection<StockMovementStockSerialMap>? StockMovementStockSerialMaps { get; set; }
    }
}