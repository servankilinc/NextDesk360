using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class CompanyProductStockSerialMap : IEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CompanyProductId { get; set; }
        public Guid StockSerialId { get; set; }
        
        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion
        public virtual CompanyProduct? CompanyProduct { get; set; }
        public virtual StockSerial? StockSerial { get; set; }
    }
}