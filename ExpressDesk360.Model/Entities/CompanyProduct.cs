using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class CompanyProduct : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public Guid? StockId { get; set; }
        public Guid? BOMId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Stock? Stock { get; set; }
        public virtual BOM? BOM { get; set; }
        public virtual ICollection<CompanyProductStockSerialMap>? CompanyProductStockSerialMaps { get; set; }
        public virtual ICollection<CompanyProductWarranty>? CompanyProductWarranties { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}