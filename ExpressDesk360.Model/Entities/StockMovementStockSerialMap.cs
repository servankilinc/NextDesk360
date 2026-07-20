using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockMovementStockSerialMap : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public Guid StockMovementId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual StockSerial? StockSerial { get; set; }
        public virtual StockMovement? StockMovement { get; set; }
    }
}