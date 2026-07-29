using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockMovementStockSerialMap : IEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public Guid StockMovementId { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion
        public virtual StockSerial? StockSerial { get; set; }
        public virtual StockMovement? StockMovement { get; set; }
    }
}