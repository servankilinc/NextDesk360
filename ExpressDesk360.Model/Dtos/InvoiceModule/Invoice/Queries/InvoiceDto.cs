using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.InvoiceModule.Invoice.Queries;

public class InvoiceDto : IDto
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
}