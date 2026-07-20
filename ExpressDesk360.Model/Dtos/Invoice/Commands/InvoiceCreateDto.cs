using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Invoice.Commands
{
    public class InvoiceCreateDto : IDto
    {
        public int InvoiceTypeId { get; set; }
        public string? InvoiceNo { get; set; }
        public int ItemNumber { get; set; }
        public Guid? SellerCompanyId { get; set; }
        public Guid? BuyerCompanyId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public decimal? DiscountAmount1 { get; set; }
        public decimal? DiscountAmount2 { get; set; }
        public decimal? DiscountRate1 { get; set; }
        public decimal? DiscountRate2 { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal GrandTotal { get; set; } = 0;
        public int CurrencyId { get; set; }
        public decimal? ExchangeRate { get; set; }
    }

    public class InvoiceCreateDtoValidator : AbstractValidator<InvoiceCreateDto>
    {
        public InvoiceCreateDtoValidator()
        {
            RuleFor(v => v.InvoiceTypeId).NotNull();
            RuleFor(v => v.ItemNumber).NotNull();
            RuleFor(v => v.TotalPrice).NotNull();
            RuleFor(v => v.GrandTotal).NotNull();
            RuleFor(v => v.CurrencyId).NotNull();
        }
    }
}