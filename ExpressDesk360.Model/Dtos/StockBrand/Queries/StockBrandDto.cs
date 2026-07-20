using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockBrand.Queries
{
    public class StockBrandDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}