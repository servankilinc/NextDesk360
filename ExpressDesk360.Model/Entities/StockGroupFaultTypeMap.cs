using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockGroupFaultTypeMap : IEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public int FaultTypeId { get; set; }
        public int StockGroupId { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }

        #endregion
        public virtual FaultType? FaultType { get; set; }
        public virtual StockGroup? StockGroup { get; set; }
    }
}