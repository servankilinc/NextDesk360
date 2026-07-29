using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class WarrantyType : IEntity, IActivatableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<CompanyProductWarranty>? CompanyProductWarranties { get; set; }
        public virtual ICollection<StockSerialWarranty>? StockSerialWarranties { get; set; }
    }
}