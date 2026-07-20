using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class Currency : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }
        public virtual ICollection<Shipping>? PriceCurrencyShippings { get; set; }
        public virtual ICollection<Stock>? PurchaseCurrencyStocks { get; set; }
        public virtual ICollection<Stock>? SalePriceCurrencyStocks { get; set; }
        public virtual ICollection<TicketServicePrice>? TicketServicePrices { get; set; }
    }
}