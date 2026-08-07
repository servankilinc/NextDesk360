using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.InvoiceModule;
using ExpressDesk360.Model.Entities.ProductionModule;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Model.Entities.StockModule;

public class StockMovement : IEntity, IImmutableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid StockId { get; set; }
    public int StockMovementTypeId { get; set; }
    public Guid? UserId { get; set; }
    public decimal Quantity { get; set; }
    public Guid? InvoiceId { get; set; }
    public Guid? TicketMovementId { get; set; }
    public int? WarehouseId { get; set; }
    public DateTime Date { get; set; }
    public Guid? CompanyProductId { get; set; }
    public int? FaultTypeId { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Stock? Stock { get; set; }
    public virtual StockMovementType? StockMovementType { get; set; }
    public virtual User? User { get; set; }
    public virtual Invoice? Invoice { get; set; }
    public virtual TicketMovement? TicketMovement { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
    public virtual CompanyProduct? CompanyProduct { get; set; }
    public virtual FaultType? FaultType { get; set; }
    public virtual ICollection<StockMovementStockSerialMap>? StockMovementStockSerialMaps { get; set; }
}