using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.InvoiceType.Queries
{
    public class InvoiceTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public char InOutCode { get; set; }
        public string? NumberStart { get; set; }
        public byte Status { get; set; }
    }
}