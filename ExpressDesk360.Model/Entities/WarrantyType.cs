using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class WarrantyType : IEntity, ISoftDeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        #region ISoftDeletableEntity
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        #endregion

        public virtual ICollection<CompanyProductWarranty>? CompanyProductWarranties { get; set; }
        public virtual ICollection<StockSerialWarranty>? StockSerialWarranties { get; set; }
    }
}