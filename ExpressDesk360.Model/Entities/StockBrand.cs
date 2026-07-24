using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class StockBrand : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

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

        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<StockGroupBrandMap>? StockGroupBrandMaps { get; set; }
    }
}