using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.StockGroup.Queries
{
    public class StockGroupDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}