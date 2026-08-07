using ExpressDesk360.Core.Model;
using ExpressDesk360.Core.Utils.DeleteBehavior;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Model.Entities.InvoiceModule;

public class Invoice : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public int InvoiceTypeId { get; set; }
    public string? InvoiceNo { get; set; }
    public int ItemNumber { get; set; }
    public Guid? SellerCompanyId { get; set; }
    public Guid? BuyerCompanyId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal? DiscountAmount1 { get; set; }
    public decimal? DiscountAmount2 { get; set; }
    public decimal? DiscountRate1 { get; set; }
    public decimal? DiscountRate2 { get; set; }
    public decimal? TaxTotal { get; set; }
    public decimal GrandTotal { get; set; }
    public int CurrencyId { get; set; }
    public decimal? ExchangeRate { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    #region ISoftDeletableEntity
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateUtc { get; set; }
    #endregion

    public virtual InvoiceType? InvoiceType { get; set; }
    public virtual Company? SellerCompany { get; set; }
    public virtual Company? BuyerCompany { get; set; }
    public virtual Currency? Currency { get; set; }
    
    [RestrictDelete]
    public virtual ICollection<StockMovement>? StockMovements { get; set; }
}