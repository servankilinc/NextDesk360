using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class BOMItem : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid BOMId { get; set; }
        public Guid StockId { get; set; }
        public decimal Quantity { get; set; }

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

        public virtual BOM? BOM { get; set; }
        public virtual Stock? Stock { get; set; }
    }
}