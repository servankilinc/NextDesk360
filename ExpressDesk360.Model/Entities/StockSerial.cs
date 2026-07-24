using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockSerial : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string? SerialNumber { get; set; }
        public Guid? CompanyId { get; set; }
        public int? WarehouseId { get; set; }
        
        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; } 
        #endregion

        #region ISoftDeletableEntity
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; } 
        #endregion
        
        public virtual Stock? Stock { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public virtual ICollection<CompanyProductStockSerialMap>? CompanyProductStockSerialMaps { get; set; }
        public virtual ICollection<StockMovementStockSerialMap>? StockMovementStockSerialMaps { get; set; }
        public virtual ICollection<StockSerialWarranty>? StockSerialWarranties { get; set; }
    }
}