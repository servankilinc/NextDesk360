using ExpressDesk360.Core.Model;
using ExpressDesk360.Core.Utils.DeleteBehavior;

namespace ExpressDesk360.Model.Entities
{
    public class BOM : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public string? VersionName { get; set; }
        public bool Status { get; set; }

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

        [CascadeDelete]
        public virtual ICollection<BOMItem>? BOMItems { get; set; }
        public virtual ICollection<CompanyProduct>? CompanyProducts { get; set; }
    }
}