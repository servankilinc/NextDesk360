using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.ProductionModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Model.Entities.Common;

public class WarrantyType : IEntity, IActivatableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual ICollection<CompanyProductWarranty>? CompanyProductWarranties { get; set; }
    public virtual ICollection<StockSerialWarranty>? StockSerialWarranties { get; set; }
}