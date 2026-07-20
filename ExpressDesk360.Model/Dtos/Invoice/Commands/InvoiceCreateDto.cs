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

    public class InvoiceCreateDtoValidator : AbstractValidator<InvoiceCreateDto>
    {
        public InvoiceCreateDtoValidator()
        {
            RuleFor(v => v.InvoiceTypeId).GreaterThan(0).WithMessage("InvoiceTypeId must be greater than 0");
            RuleFor(v => v.ItemNumber).GreaterThan(0).WithMessage("ItemNumber must be greater than 0");
            RuleFor(v => v.TotalPrice).GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
            RuleFor(v => v.GrandTotal).GreaterThan(0).WithMessage("GrandTotal must be greater than 0");
            RuleFor(v => v.CurrencyId).GreaterThan(0).WithMessage("CurrencyId must be greater than 0");
        }
    }
}