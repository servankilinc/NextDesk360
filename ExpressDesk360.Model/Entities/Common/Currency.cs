using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.InvoiceModule;
using ExpressDesk360.Model.Entities.ShippingModule;
using ExpressDesk360.Model.Entities.StockModule;
using ExpressDesk360.Model.Entities.TicketModule;

namespace ExpressDesk360.Model.Entities.Common;

public class Currency : IEntity, IActivatableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<Invoice>? Invoices { get; set; }
    public virtual ICollection<Shipping>? PriceCurrencyShippings { get; set; }
    public virtual ICollection<Stock>? PurchaseCurrencyStocks { get; set; }
    public virtual ICollection<Stock>? SalePriceCurrencyStocks { get; set; }
    public virtual ICollection<TicketServicePrice>? TicketServicePrices { get; set; }
}