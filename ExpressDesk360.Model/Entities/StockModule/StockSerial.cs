using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.Model.Entities.StockModule;

public class StockSerial : IEntity, IActivatableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid StockId { get; set; }
    public string? SerialNumber { get; set; }
    public Guid? CompanyId { get; set; }
    public int? WarehouseId { get; set; }

    public bool IsActive { get; set; } = true;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Stock? Stock { get; set; }
    public virtual Company? Company { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
    public virtual ICollection<CompanyProductStockSerialMap>? CompanyProductStockSerialMaps { get; set; }
    public virtual ICollection<StockMovementStockSerialMap>? StockMovementStockSerialMaps { get; set; }
    public virtual ICollection<StockSerialWarranty>? StockSerialWarranties { get; set; }
}