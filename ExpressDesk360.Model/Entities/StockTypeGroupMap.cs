using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockTypeGroupMap : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public int StockTypeId { get; set; }
        public int StockGroupId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual StockType? StockType { get; set; }
        public virtual StockGroup? StockGroup { get; set; }
    }
}