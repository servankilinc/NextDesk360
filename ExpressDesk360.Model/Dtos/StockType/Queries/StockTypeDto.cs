using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockType.Queries
{
    public class StockTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}