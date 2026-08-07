using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.CompanyModule;

namespace ExpressDesk360.Model.Entities.StockModule;

public class Warehouse : IEntity, IActivatableEntity, IAuditableEntity
{
    public int Id { get; set; }
    public Guid CompanyId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Company? Company { get; set; }
    public virtual ICollection<StockMovement>? StockMovements { get; set; }
    public virtual ICollection<StockSerial>? StockSerials { get; set; }
}