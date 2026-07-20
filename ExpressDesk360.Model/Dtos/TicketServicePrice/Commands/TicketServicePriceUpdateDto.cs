using ExpressDesk360.Core.Model;
using FluentValidation;

namespace ExpressDesk360.Model.Dtos.TicketServicePrice.Commands
{
    public class TicketServicePriceUpdateDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public decimal? MaterialPrice { get; set; }
        public decimal? ServicePrice { get; set; }
        public decimal? AnotherPrice { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal ServiceTotal { get; set; } = 0;
        public int CurrencyId { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? ServiceDescription { get; set; }
    }

    public class TicketServicePriceUpdateDtoValidator : AbstractValidator<TicketServicePriceUpdateDto>
    {
        public TicketServicePriceUpdateDtoValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid guid value");
            RuleFor(v => v.TicketId).NotEqual(Guid.Empty).WithMessage("TicketId must be a valid guid value");
            RuleFor(v => v.ServiceTotal).NotNull();
            RuleFor(v => v.CurrencyId).NotNull();
        }
    }
}