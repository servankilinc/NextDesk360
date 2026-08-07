using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.Model.Entities.StockModule;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Model.Entities.ProductionModule;

public class CompanyProduct : IEntity, IAuditableEntity, IActivatableEntity
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public Guid? StockId { get; set; }
    public Guid? BOMId { get; set; }

    public bool IsActive { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Company? Company { get; set; }
    public virtual Stock? Stock { get; set; }
    public virtual BOM? BOM { get; set; }
    public virtual ICollection<CompanyProductStockSerialMap>? CompanyProductStockSerialMaps { get; set; }
    public virtual ICollection<CompanyProductWarranty>? CompanyProductWarranties { get; set; }
    public virtual ICollection<Ticket>? Tickets { get; set; }
    public virtual ICollection<StockMovement>? StockMovements { get; set; }
}