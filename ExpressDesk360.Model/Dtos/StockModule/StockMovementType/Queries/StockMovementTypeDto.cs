using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockModule.StockMovementType.Queries
{
    public class StockMovementTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public char InOutCode { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}