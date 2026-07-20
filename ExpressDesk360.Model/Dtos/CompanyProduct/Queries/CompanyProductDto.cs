using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.CompanyProduct.Queries
{
    public class CompanyProductDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public Guid? StockId { get; set; }
        public Guid? BOMId { get; set; }
    }
}