using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.Model.Entities.ProductionModule;

namespace ExpressDesk360.Model.Entities.StockModule;

public class Stock : IEntity, IActivatableEntity, IArchivableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public int StockGroupId { get; set; }
    public int StockBrandId { get; set; }
    public string? ModelName { get; set; }
    public string? ModelCode { get; set; }
    public string? ModelType { get; set; }
    public int? UnitId { get; set; }
    public bool SerialTracking { get; set; }
    public bool VirtualSeries { get; set; }
    public string? SerialNumberStart { get; set; }
    public decimal Vat { get; set; }
    public decimal? PurchasePrice { get; set; }
    public int? PurchaseCurrencyId { get; set; }
    public decimal? SalePrice { get; set; }
    public int? SalePriceCurrencyId { get; set; }

    public bool IsActive { get; set; } = true;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual StockGroup? StockGroup { get; set; }
    public virtual StockBrand? StockBrand { get; set; }
    public virtual Unit? Unit { get; set; }
    public virtual Currency? PurchaseCurrency { get; set; }
    public virtual Currency? SalePriceCurrency { get; set; }
    public virtual ICollection<BOM>? BOMs { get; set; }
    public virtual ICollection<BOMItem>? BOMItems { get; set; }
    public virtual ICollection<CompanyProduct>? CompanyProducts { get; set; }
    public virtual ICollection<StockMovement>? StockMovements { get; set; }
    public virtual ICollection<StockSerial>? StockSerials { get; set; }
}