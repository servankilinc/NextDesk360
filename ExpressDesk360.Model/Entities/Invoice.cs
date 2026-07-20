using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
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
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual InvoiceType? InvoiceType { get; set; }
        public virtual Company? SellerCompany { get; set; }
        public virtual Company? BuyerCompany { get; set; }
        public virtual Currency? Currency { get; set; }
        public virtual ICollection<StockMovement>? StockMovements { get; set; }
    }
}