using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Model.Entities.ProductionModule;

public class BOMItem : IEntity, IAuditableEntity, IActivatableEntity
{
    public Guid Id { get; set; }
    public Guid BOMId { get; set; }
    public Guid StockId { get; set; }
    public decimal Quantity { get; set; }

    public bool IsActive { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual BOM? BOM { get; set; }
    public virtual Stock? Stock { get; set; }
}