using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Model.Entities.ProductionModule;

public class BOM : IEntity, IAuditableEntity, IActivatableEntity
{
    public Guid Id { get; set; }
    public Guid StockId { get; set; }
    public string? VersionName { get; set; }
    public bool Status { get; set; }

    public bool IsActive { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Stock? Stock { get; set; }
    public virtual ICollection<BOMItem>? BOMItems { get; set; }
    public virtual ICollection<CompanyProduct>? CompanyProducts { get; set; }
}