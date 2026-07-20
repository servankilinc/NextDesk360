using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.Invoice.Commands
{
    public class InvoiceUpdateDto : IDto
    {
        public Guid Id { get; set; }
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

    public class InvoiceUpdateDtoValidator : AbstractValidator<InvoiceUpdateDto>
    {
        public InvoiceUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.InvoiceTypeId).NotNull();
            RuleFor(v => v.ItemNumber).NotNull();
            RuleFor(v => v.TotalPrice).NotNull();
            RuleFor(v => v.GrandTotal).NotNull();
            RuleFor(v => v.CurrencyId).NotNull();
        }
    }
}