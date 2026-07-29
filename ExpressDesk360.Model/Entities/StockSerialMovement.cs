using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockSerialMovement : IEntity, IImmutableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid StockSerialId { get; set; }
        public int StockSerialMovementTypeId { get; set; }
        public DateTime Date { get; set; }
        public int? WarehouseId { get; set; }
        public Guid? CompanyProductId { get; set; }
        public int? FaultTypeId { get; set; }
        public Guid? TicketId { get; set; }
        public Guid? UserId { get; set; }
        public string? Description { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion

        #region IImmutableEntity
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        #endregion

        public virtual StockSerial? StockSerial { get; set; }
        public virtual StockSerialMovementType? StockSerialMovementType { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public virtual CompanyProduct? CompanyProduct { get; set; }
        public virtual FaultType? FaultType { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual User? User { get; set; }
    }
}
