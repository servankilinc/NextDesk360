using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.TicketModule.TicketServicePrice.Queries
{
    public class TicketServicePriceDto : IDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public decimal? MaterialPrice { get; set; }
        public decimal? ServicePrice { get; set; }
        public decimal? AnotherPrice { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal ServiceTotal { get; set; }
        public int CurrencyId { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? ServiceDescription { get; set; }
    }
}